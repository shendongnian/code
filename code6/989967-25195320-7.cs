    public class StarSystem
    {
        public int Minerals { get; set; }
        public string Name { get; private set; }
  
        public StarSystem(string name) 
        {
            Name = name;
        }
    }
