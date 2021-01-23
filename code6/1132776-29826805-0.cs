    public void WriteSingleNode(this XmlDocument document, string NodeName, string InnerText)
            {
    
                // Create a new element node.
                XmlNode newElem = document.CreateNode("element", "pages", "");
                newElem.InnerText = InnerText;
    
                Console.WriteLine("Add the new element to the document...");
                document.DocumentElement.AppendChild(newElem);
    
                Console.WriteLine("Display the modified XML document...");
                Console.WriteLine(document.OuterXml);
            }
