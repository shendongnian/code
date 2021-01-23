        static void Main(string[] args)
        {
            try
            {
                List<FolkbokforingspostTYPE> deserializedList = new List<FolkbokforingspostTYPE>();
                deserializedList = Deserialize<List<FolkbokforingspostTYPE>>();
                var PersonalIdentityNumber = deserializedList.Select(item => item.Personpost.PersonId.PersonNr).FirstOrDefault();
            }// Put a break-point here, then mouse-over PersonalIdentityNumber...  deserializedList contains everything if you need it
            catch (Exception)
            {
                throw;
            }
        }
        private static T Deserialize<T>() where T : new()
        {
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
