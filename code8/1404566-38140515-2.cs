    public class A
    {
        public string Text { get; set; }
    }
    
    public class B : A
    {
        new public int Text { get; set; }
    }
    B b = new B();
    b.Text = 4;
    
    // Upcast B to A
    A a = b;
    a.Text = "Bye bye";
    Console.WriteLine(a.Text); // Output: Bye bye
    Console.WriteLine(b.Text); // Output: 4
