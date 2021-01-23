     XmlSerializer serializer = new XmlSerializer(typeof(AllData));
     using(StringWriter sww = new StringWriter())
     using(XmlWriter writer = XmlWriter.Create(sww))
     {
         serializer.Serialize(writer, alldata); // your object
         var xml = sww.ToString(); // your xml.
         // save your xml
     }
