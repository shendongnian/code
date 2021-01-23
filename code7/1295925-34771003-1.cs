            Request request;
            var fileName = "File1.xml";
            //Parsing
            var sr = new XmlSerializer(typeof(Request));
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                request = (Request)sr.Deserialize(fs);
            }
            //Selecting distinct C# logic
            var distinctAssignments = request.Client.Assignment.Assessments.Distinct();
            request.Client.Assignment.Assessments = distinctAssignments.ToArray();
            //Saving your document
            var xmlDocument = new XmlDocument();
            using (var stream = new MemoryStream())
            {
                sr.Serialize(stream, request);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(fileName);
                stream.Close();
            }
