        static void TestMain2(string[] args)
        {
            List<Candidate> source = new List<Candidate>()
            {
                new Candidate() { Id = 1, Email = "test1@test.com", Title = "Mr", FirstName = "Fred", LastName = "Flintstone", AreasInterest = "Area1", Phone = "+44 1234 123123" },
                new Candidate() { Id = 3, Email = "test2@test.com", Title = "Mr", FirstName = "Barney", LastName = "Rubble", AreasInterest = "Area2", Phone = "+44 1234 231231" },
                new Candidate() { Id = 2, Email = "test3@test.com", Title = "Mrs", FirstName = "Wilma", LastName = "Flintstone", AreasInterest = "Area3", Phone = "+44 1234 312312" }
            };
            WriteCSVFile(source);
        }
        private static void WriteCSVFile(List<Candidate> dataSource)
        {
            //filehelper object
            FileHelperEngine engine = new FileHelperEngine(typeof(Candidate));
            List<Candidate> csv = new List<Candidate>();
            //convert any datasource to csv based object
            foreach (var item in dataSource)
            {
                Candidate temp = new Candidate();
                temp.Title = item.Title;
                temp.FirstName = item.FirstName;
                temp.LastName = item.LastName;
                temp.Email = item.Email;
                temp.Phone = item.Phone;
                temp.AreasInterest = item.AreasInterest;
                csv.Add(temp);
            } // end foreach
            //give file a name and header text
            engine.HeaderText = "Title,FirstName,LastName,Email,Phone,AreaInterest";
            //save file locally
            engine.WriteFile("export.csv", csv);
        } // end method WriteCSVFile
