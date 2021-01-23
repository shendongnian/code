    public class Person
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public virtual Person Parent { set; get; }
        public virtual Person Kid { set; get; }    
    }
