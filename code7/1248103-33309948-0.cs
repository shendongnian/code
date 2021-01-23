    // same code till this
    // get horse element from horseXml
    XmlElement horseEl = horseXml.DocumentElement; //[1] get the doc element
    // assign xmldb to xml document
    var xmlDb = new XmlDocument();
    xmlDb.Load(xmlDbFilepath);
    //XmlNode root = xmlDb.DocumentElement; [2] removed
    // add horseEl to root of xmlDb
    //var newRoot = root.AppendChild(clonedHorseEl); [3] removed
    var xe = xmlDb.CreateElement("Horse"); //[4] Create new Horse element on xmlDb
    xe.InnerXml = horseEl.InnerXml; //[5] copy horseEl content
    xmlDb.DocumentElement.AppendChild(xe);
            
    xmlDb.Save(xmlDbFilepath);
