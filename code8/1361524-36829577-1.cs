        static void Main(string[] args)
        {
            List<Pogos> dObjToSerialize = new List<Pogos>();
            dObjToSerialize.Add(new Pogos() { Date = DateTime.Now, Pogo = "Pogo 1" });
            dObjToSerialize.Add(new Pogos() { Date = DateTime.Now, Pogo = "Pogo 2" });
            dObjToSerialize.Add(new Pogos() { Date = DateTime.Now, Pogo = "Pogo 3" });
            dObjToSerialize.Add(new Pogos() { Date = DateTime.Now, Pogo = "Pogo 4" });
            Serialize(dObjToSerialize); // find you XML in a file called "xml.xml" in the build folder
            List<Pogos> dObjToDeserialize = Deserialize<List<Pogos>>();
        } // Put a break-point here and dObjToDeserialize will contain your objects from the "xml.xml"
        private static void Serialize<T>(T data)
        {
            // Use a file stream here.
            using (TextWriter WriteFileStream = new StreamWriter("xml.xml"))
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
        private static T Deserialize<T>() where T : new()
        {
            //List<Employee> EmployeeList2 = new List<Employee>();
            // Create an instance of T
            T ReturnListOfT = CreateInstance<T>();
            // Create a new file stream for reading the XML file
            using (FileStream ReadFileStream = new FileStream("xml.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
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
    }
