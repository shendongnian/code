         // Create an instance of CallsignRecordclass.
         CallsignRecord serializeObject = new CallsignRecord();
         // Create an instance of new TextReader.
         TextReadertxtReader = new StreamReader(@”C:\Callsigns.xml”);
         // Create and instance of XmlSerializer class.
         XmlSerializerxmlSerializer = new XmlSerializer(typeof(CallsignRecord));
         // Deserialize from the StreamReader.
         serializeObject = (CallsignRecord)xmlSerializer.Deserialize(txtReader);
         // Close the stream reader
         txtReader.Close();
