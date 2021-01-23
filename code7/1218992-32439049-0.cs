    // Case 1
    public class A
    {
        public string Name { get; private set; }
    
        public void DoStuff() 
        {
            Name = "Whatever";
        }
    }
    // Case 2
    public class A
    {
        // This property will be settable unless the code accessing it
        // lives outside the assembly where A is contained...
        public string Name { get; internal set; }
    }
    // Case 3
    public class A
    {
        // This property will be settable in derived classes...
        public string Name { get; protected set; }
    }
    // Case 4: readonly fields is the nearest way to design an immutable object
    public class A
    {
         public readonly string Text = "Hello world";
    }
