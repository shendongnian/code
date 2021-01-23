    var xdoc = XDocument.Parse(
                @"<?xml version=""1.0"" encoding=""utf-8""?>
                    <Tool_Parent>
                      <tool name=""ABCD"" id=""226"">
                        <category>Centralized</category>
                        <extension_id>0</extension_id>
                        <uses_ids>16824943 16824944</uses_ids>
                      </tool>
                      <tool name=""EFGH"" id=""228"">
                        <category>Automated</category>
                        <extension_id>0</extension_id>
                        <uses_ids>92440 16824</uses_ids>
                      </tool>
                    </Tool_Parent>");
            var root = xdoc.Root; // Got to have that root
            if (root != null)
            {
                var id228query = (from toolElement in root.Elements("tool")
                    where toolElement.HasAttributes
                    where toolElement.Attribute("id").Value.Equals("228")
                    let xElement = toolElement.Element("uses_ids")
                    where xElement != null
                    select xElement.Value).FirstOrDefault();
                Console.WriteLine(id228query);
                Console.Read();
            }
    Output: 92440 16824
    
