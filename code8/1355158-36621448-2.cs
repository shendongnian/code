        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Candidatelist Candidatelist = new Candidatelist();
                Candidatelist.Comment = "created 15.03.2016";
                Candidate candidate1 = new Candidate();
                candidate1.Personalinfo = new Personalinfo() { Name = "Parker", Firstname = "Peter", Sex = "M", Birthday = "19.02.1993", Group = "group1", Language = "E", Type = "H" };
                candidate1.Items.Item.Add("Item1");
                candidate1.Items.Item.Add("Item2");
                candidate1.Items.Item.Add("Item3");
                candidate1.Items.Item.Add("Item4");
                candidate1.Items.Item.Add("Item5");
                candidate1.Items.Item.Add("Item6");
                candidate1.Items.Item.Add("Item7");
                candidate1.Items.Item.Add("Item8");
                Candidatelist.Candidates.Candidate.Add(candidate1);
                Candidate candidate2 = new Candidate();
                candidate2.Personalinfo = new Personalinfo() { Name = "John", Firstname = "Doe", Sex = "M", Birthday = "19.02.1993", Group = "group1", Language = "E", Type = "H" };
                candidate2.Items.Item.Add("Item1");
                candidate2.Items.Item.Add("Item2");
                candidate2.Items.Item.Add("Item3");
                candidate2.Items.Item.Add("Item4");
                candidate2.Items.Item.Add("Item5");
                candidate2.Items.Item.Add("Item6");
                candidate2.Items.Item.Add("Item7");
                candidate2.Items.Item.Add("Item8");
                Candidatelist.Candidates.Candidate.Add(candidate2);
                // and to Serialize to XML
                Serialize(Candidatelist);
                // and to Deserialize from XML
                Candidatelist deserializedCandidatelist = Deserialize<Candidatelist>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static void Serialize<T>(T data)
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
        private static T Deserialize<T>() where T : new()
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
