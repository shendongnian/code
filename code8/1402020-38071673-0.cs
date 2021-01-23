    var nodeNames = new [] { "Name", "Description", "Synonym_Name" };
    
    var nodeContents = nodeNames
                           .Select(xmlDoc.GetElementsByTagName)
                           .Select(_ => _.Cast<XmlNode>())
                           .SelectMany(_ => _)
                           .Select(node => 
                           {
                                var stringBuilder = new StringBuilder();
                            
                                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
                            
                                using (var writer = XmlTextWriter.Create(stringBuilder, settings))
                                {
                                    node.WriteTo(writer);
                            
                                    writer.Flush();
                            
                                    return stringBuilder.ToString();
                                }
                            });
    var box = new System.Windows.Controls.TextBox();
    box.Text = string.Concat(nodeContents);
