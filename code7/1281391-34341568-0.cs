    public class Person
    {
        public string name;
        public int id;
    
        [Obsolete("this should not be used", true)]
        public new string ToString()
        {
            return null;
        }
    }
