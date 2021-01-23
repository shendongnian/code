        // the name of the class must match the name of your database table
        // the names of properties must match your column names
        public class Localization 
        {
            [PrimaryKey]
            public int Id { get; set; }
            public string Word { get; set; }
            public string Translation { get; set; }
        }
