    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using LibGit2Sharp;
    
    namespace libgitblob
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var repo = new Repository ("/Users/administrator/code/playscript/playscriptredux/playscript");
    			foreach (var item in repo.RetrieveStatus()) {
    				if (item.State == FileStatus.Modified) {
    					var patch = repo.Diff.Compare<Patch> (new List<string>() { item.FilePath });
    					var blob = repo.Head.Tip[item.FilePath].Target as Blob;
    					string commitContent;
    					using (var content = new StreamReader(blob.GetContentStream(), Encoding.UTF8))
    					{
    						commitContent = content.ReadToEnd();
    					}
    					string workingContent;
    					using (var content = new StreamReader(repo.Info.WorkingDirectory + Path.DirectorySeparatorChar + item.FilePath, Encoding.UTF8))
    					{
    						workingContent = content.ReadToEnd();
    					}
    					Console.WriteLine ("~~~~ Patch file ~~~~");
    					Console.WriteLine (patch.Content);
    					Console.WriteLine ("\n\n~~~~ Original file ~~~~");
    					Console.WriteLine(commitContent);
    					Console.WriteLine ("\n\n~~~~ Current file ~~~~");
    					Console.WriteLine(workingContent);
    				}
    			}
    		}
    	}
    }
