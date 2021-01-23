        //  1.- Data
        var data = new Data();
        var calls = new List<Call>
        {
            new Call
            {
                Entry = new DateTime(2016, 1, 15, 14, 45, 24, 447),
                Exit = new DateTime(2016, 1, 15, 15, 45, 24, 447)
            },
            new Call
            {
                Entry = new DateTime(2016, 1, 15, 15, 46, 35, 637),
                Exit = new DateTime(2016, 1, 15, 16, 46, 35, 637)
            }
        };
        data.Calls = new List<Call>(calls);
        //  2.- Serialize the objet to byte[]
        var dataByteArray = new XmlSerializerHelper<Data>().ObjectToByteArray(data, Encoding.GetEncoding("UTF-8"), true);
        //  3.- Save the byte[] to disk
        File.WriteAllBytes("D:/xml.xml", dataByteArray);
