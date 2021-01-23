    using System.IO;
    using System.Xml.Serialization;
    var serializer = new XmlSerializer(typeof(CommandList));
    var result = (CommandList)serializer.Deserialize(File.OpenRead("input.xml"));
    var output = new List<string>();
    foreach (var command in result.Commands)
    {
        command.Process(output);
    }
