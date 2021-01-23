    string yourPointsFile = "d:\\myPoints.xml";
    XmlSerializer xmls = new XmlSerializer(typeof(List<Point>));
    // save the points:
    using (Stream writer = new FileStream(yourPointsFile, FileMode.Create))
    {
        xmls.Serialize(writer, points);
        writer.Close();
    }
    // load the points
    using (Stream reader = new FileStream(yourPointsFile, FileMode.Open))
    {
        var points2 = xmls.Deserialize(reader);
        reader.Close();
    }
