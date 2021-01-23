        public class Notes
        {
            [PrimaryKey, AutoIncrement, NotNull] 
            public int Id { get; set; } 
            public string Name { get; set; } 
            public string Note { get; set; } 
            public string Date { get; set; } 
            public bool Done { get; set; } 
        }
