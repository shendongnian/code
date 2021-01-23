    public class A
    {
        public string Text { get; set; }
    }
    
    public class B : A
    {
        new public int Text { get; set; }
    }
