        static void Main(string[] args)
        {
            Root dezerializedXML = new Root();
            // Deserialize to object
            XmlSerializer serializer = new XmlSerializer(typeof(Root));
            using (FileStream stream = File.OpenRead(@"xml.xml"))
            {
                dezerializedXML = (Root)serializer.Deserialize(stream);
            } // Put a break-point here, then mouse-over dezerializedXML
            // the next line will get both of the services at that level in your XML you can probably do something with that
            var v = (dezerializedXML.Device.DeviceList.Device.DeviceList.Device.ServiceList.Service);
        }
