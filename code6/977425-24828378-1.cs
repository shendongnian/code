    public class Names
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public Names() { }
        public static List<Names> SampleData()
        {
            return new List<Names>()
            {
                    new Names(){ Id = 1, Name = "Name1" },
                    new Names(){ Id = 2, Name = "Name2" },
                    new Names(){ Id = 2, Name = "Name2" },
                    new Names(){ Id = 3, Name = "Name3" },
            };
        }
    }
