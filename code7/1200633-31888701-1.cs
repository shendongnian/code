    public void DoWhatever(){
            pathsSettings myObject;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer = new XmlSerializer(typeof(pathsSettings));
            // To read the file, create a FileStream.
            FileStream myFileStream = new FileStream(@"yourpath\Path.config", FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            myObject = (pathsSettings)mySerializer.Deserialize(myFileStream);
            foreach(add addObj in myObject.paths)
            {
                Console.WriteLine(addObj.Path);
                Console.WriteLine(addObj.TemplateId);
            }
    }
