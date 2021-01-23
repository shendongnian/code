        public class Player
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public virtual Team Team { get; set; }
        }
