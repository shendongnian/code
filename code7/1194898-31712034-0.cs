        public static DataTable DoSomething() 
        {
            DataTable table = new DataTable();
            table.Columns.Add("Student Name");
            table.Columns.Add("Student Number");
            table.Columns.Add("Registered");
            getJsonData data = new JavaScriptSerializer().Deserialize<getJsonData>(System.IO.File.ReadAllText(@"C:\Users\mailb_000\Downloads\texts\test.json"));
            foreach (var item in data.students)
            {
                table.Rows.Add(item.Name, item.StudentNo, item.registered);
                Debug.Write(table);
            }
            return table;
        }
        public class getJsonData
        {
            public List<students> students { get; set; }
        }
        public class students
        {
            public string Name { get; set; }
            public int StudentNo { get; set; }
            public string registered { get; set; }
        }
