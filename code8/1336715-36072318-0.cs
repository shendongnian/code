        private void Serialize<T>(T data)
        {
            // Use a file stream here.
            using (TextWriter WriteFileStream = new StreamWriter("test.xml"))
            {
                // Construct a SoapFormatter and use it  
                // to serialize the data to the stream.
                XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                try
                {
                    // Serialize EmployeeList to the file stream
                    SerializerObj.Serialize(WriteFileStream, data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to serialize. Reason: {0}", ex.Message));
                }
            }
        }
        private T Deserialize<T>() where T : new()
        {
            //List<Employee> EmployeeList2 = new List<Employee>();
            // Create an instance of T
            T ReturnListOfT = CreateInstance<T>();
            // Create a new file stream for reading the XML file
            using (FileStream ReadFileStream = new FileStream("test.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // Construct a XmlSerializer and use it  
                // to serialize the data from the stream.
                XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
                try
                {
                    // Deserialize the hashtable from the file
                    ReturnListOfT = (T)SerializerObj.Deserialize(ReadFileStream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Failed to serialize. Reason: {0}", ex.Message));
                }
            }
            // return the Deserialized data.
            return ReturnListOfT;
        }
        // function to create instance of T
        public static T CreateInstance<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
