    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace MergeResx
    {
    	static class Program
    	{
    		static void Main(string[] args)
    		{
    			var settings = args
    				.Select(arg => arg[0] == '-' ? ("keys", arg.TrimStart('-')) : Directory.Exists(arg) ? ("directories", arg) : File.Exists(arg) ? ("sources", arg) : ("targets", arg))
    				.Concat(new (string, string)[] { ("keys", null), ("directories", null), ("sources", null), ("targets", null), })
    				.GroupBy(item => item.Item1)
    				.ToDictionary(group => group.Key, group => group.Select(item => item.Item2).Where(item => !string.IsNullOrWhiteSpace(item)))
    				;
    
    			var files = settings["directories"].Any() || settings["sources"].Any()
    				? settings["directories"]
    				.AsParallel()
    				.Select(directory => new DirectoryInfo(directory))
    				.SelectMany(directory => directory.EnumerateFiles("*.resx", SearchOption.AllDirectories))
    				.Concat(settings["sources"].AsParallel().Select(source => new FileInfo(source)))
    				: (new DirectoryInfo(Directory.GetCurrentDirectory())).EnumerateFiles()
    				;
    
    			var resources = files
    				.AsParallel()
    				.Where(file => file.Length > 0)
    				.Select(file => XDocument.Load(file.FullName))
    				.SelectMany(document => document.Root.Elements("data"))
    				.GroupBy(element => element.Attribute("name")?.Value)
    				.SelectMany(group => group
    									.GroupBy(item => item.Attribute("value")?.Value)
    									.SelectMany(grouped => !grouped.Skip(1).Any() || settings["keys"].Contains("noduplicates", StringComparer.InvariantCultureIgnoreCase)
    															? grouped.Take(1)
    															: grouped.Select(item => item.WithComment("NAME DUPLICATED IN OTHER RESX FILES DURING MERGE! LOOK AROUND THIS ELEMENT! BE CAREFULLY!"))))
    				;
    
    			new XDocument(new XElement("root", resources)).Save(settings["targets"].FirstOrDefault() ?? "Resources.resx");
    		}
    
    		static XElement WithComment(this XElement element, string comment)
    		{
    			element.AddFirst(new XComment(comment));
    			return element;
    		}
    	}
    }
