    public class Colonist
    {
        public string FirstName { get; set; }
        public string NickName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Clothing[] Clothing { get; set; }
    
        public Colonist()
        {
            Clothing = new Clothing[2];
        }
    }
    
    public class Clothing
    {
        public Color Color { get; set; }
    }
    
    public class Color
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }
    }
