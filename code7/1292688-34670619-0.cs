    public class Child
    {
        public string name = "S";
        public string age = "44";
    }
    
    public class Parent
    {
        public Parent()
        {
            Child = new Child();
        }
    
        public Child Child { get; set; }
    }
