    public interface ISome
    {
        string Text { get; set; }
    }
    
    public class A : ISome
    {
        public string Text { get; set; }
        public string Text2 { get; set; }
    }
    
    public class B : A
    {
    }
    
    // This is an upcast. You're reducing the typing of an instance of B
    ISome a = new B();
    string text2 = a.Text2; // Error, Text2 isn't a property of ISome
    string text = a.Text; // OK, Text is a property of ISome
