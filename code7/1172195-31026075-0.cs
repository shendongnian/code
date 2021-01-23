    //Static class with Access Modifier
    public class SomeClass
    {
        //Static Field with Access Modifier
        public static int intstatic = 0;
        //Static Property with Access Modifier
        public static string StaticProperty { get; set; }
        //Trying to declare static Constructor with Access Modifier
        public static SomeClass()
        { }
        //Static Method with Access Modifier
        public static void DoSomething()
        {
            Console.WriteLine(intstatic);
        }
    }
