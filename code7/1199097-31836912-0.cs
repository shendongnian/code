    public class AnObject
    {
        public Lender Lender { get; set; }
    }
    public class Lender
    {
        public Lender(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public static implicit operator Lender(string name)
        {
            return new Lender(name);
        }
        public static implicit operator string (Lender lender)
        {
            return lender.Name;
        }
    }
