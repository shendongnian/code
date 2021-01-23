    public class ClassFactory
    {
        // I'd use an Enum parameter rather than a string, but you get the idea
        public static BaseClass GetClass(string classType)
        {
            if classType.Equals("A")
                return new DerivedClassA();
            else
                return new DerivedClassB();
        }
    }
