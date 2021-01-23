    static void Main(string[] args)
    {
        string xmlSource = "<ResultSet><Result precision=\"address\">    <Latitude>47.643727</Latitude></Result></ResultSet>";
        XmlSerializer serializer = new XmlSerializer(typeof(ResultSet));
        ResultSet output;
        using (StringReader reader = new StringReader(xmlSource))
        {
            output = (ResultSet)serializer.Deserialize(reader);
        }
    }
