            public static void Serialize<T>(T data)
            {
                try // try to serialize the collection to a file
                {
                    using (Stream  stream = File.Open("data.xml", FileMode.Create))
                    {
                        // create DataContractSerializer
                        DataContractSerializer serializer = new DataContractSerializer(typeof (T));
                        // serialize the collection (EmployeeList1) to file (stream)
                        serializer.WriteObject(stream, data);
                    }
                }
                catch (IOException)
                {
                }
            }
     
            public static T Deserialize<T>() where T : new()
            {
                // Create an instance of T
                T ReturnListOfT = CreateInstance<T>();
     
                // Try to Deserialize from file stream
                try
                {
                    using (Stream stream = File.Open("data.xml", FileMode.Open))
                    {
                        // create DataContractSerializer
                        DataContractSerializer serializer = new DataContractSerializer(typeof (T));
                        // deserialize the collection (Employee) from file (stream)
                        ReturnListOfT = (T)serializer.ReadObject(stream);
                    }
                }
                catch (IOException)
                {
                }
     
                return (T)ReturnListOfT;
            }
     
            // function to create instance of T
            public static T CreateInstance<T>() where T : new()
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
