      public class Employe
    {        
        public String Name { get; set; }
        public String Rank { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
