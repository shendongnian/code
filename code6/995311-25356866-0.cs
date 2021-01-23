    static int Main(string[] args)
            {
                string strFilename = "Input.xml";
                XmlDocument xmlDoc = new XmlDocument();
    
                if (File.Exists(strFilename))
                {
                    xmlDoc.Load(strFilename);
                    XmlElement elm = xmlDoc.DocumentElement;
                    XmlNodeList lstVideos = elm.ChildNodes;
    
                    for (int i = 0; i < lstVideos.Count; i++)
                        Console.WriteLine("{0}",lstVideos[i].InnerText );
                }
                else
                    Console.WriteLine("The file {0} could not be located",
                                      strFilename);
    
                Console.WriteLine();
                return 0;
            }
