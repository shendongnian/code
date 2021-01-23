                    string path = @"path.xml";
                       if(File.Exists(path)){
                    XmlTextReader reader = new XmlTextReader(path);
                    Console.WriteLine("");
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            
                            case XmlNodeType.Element:  
                                Console.Write("<" + reader.Name);
                                Console.WriteLine(">");
                                break;
                           
                            case XmlNodeType.Text:   
                                Console.WriteLine(reader.Value);
                                break;
                            case XmlNodeType.EndElement: 
                                Console.Write("</" + reader.Name);
                                Console.WriteLine(">");
                                break;
                        }
                    }
                    Console.ReadLine();
                       }else{
                           Console.WriteLine("Error file not found");
                       }
