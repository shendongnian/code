    string yourPointsFile = "d:\\myPoints.xml";
    XmlSerializer xmls = new XmlSerializer(typeof(List<Point>));
    // save the points maybe when closing the program:
    using (Stream writer = new FileStream(yourPointsFile, FileMode.Create))
    {
        xmls.Serialize(writer, points);
        writer.Close();
    }
    // load the points at startup:
    using (Stream reader = new FileStream(yourPointsFile, FileMode.Open))
    {
        points = xmls.Deserialize(reader);
        reader.Close();
    }
