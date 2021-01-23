    void Main()
    {
    	var converter = TypeDescriptor.GetConverter(typeof(Foo));
    	Foo f = (Foo)converter.ConvertFromString("A");
    	Console.WriteLine(f); // A
    }
    
    // Define other methods and classes here
    public enum Foo {A, B, C}
