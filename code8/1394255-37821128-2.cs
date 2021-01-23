      //XElement xFile = XElement.Load("D:/Sample.xml");
            XElement xFile = XElement.Parse
                (@"<File>
                      <Cars>
                        <Car>
                          <Color>Blue</Color>
                          <Year>1988</Year>
                        </Car>
                        <Car>
                          <Color>Green</Color>
                          <Year>1989</Year>
                        </Car>
                        <Car>
                          <Color>Yellow</Color>
                          <Year>1989</Year>
                        </Car>
                      </Cars>
                    </File> ");
            List<condition> c = new List<condition>
                            {
                                new condition()
                                {
                                    color = "Green",
                                    year = "1989"
                                },
                                new condition()
                                {
                                    color = "Blue",
                                    year = "1988"
                                }
                            };
            var s = new XElement("Cars",
                    from cc in c
                    select new XElement("Car",
                        new XElement("Color", cc.color),
                        new XElement("Year", cc.year)
                    )   
                    
                    );  
            var result = xFile.Descendants("Cars").Intersect(s.Descendants("Cars"));
                
            var fileXML = new XElement("File", result);
            fileXML.Save("D:/Result.xml");
