    //XElement sitemap = XElement.Load("D:/Sample.xml");
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
            var result = new XElement("Cars",
                         from a in xFile.Descendants("Car")
                         where (a.Element("Color").Value == "Blue" && a.Element("Year").Value == "1988")
                         || (a.Element("Color").Value == "Green" && a.Element("Year").Value == "1989")
                         select a);
            var fileXML = new XElement("File", result);
            fileXML.Save("D:/Result.xml");
