    public class SomeClass
    {
        public enum Status
        {
            
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Type t = Type.GetType("Lab.SomeClass+Status", false);
            bool isEnum = t.IsEnum;
        }
    }
