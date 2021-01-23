    public class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                Utility.DoSomething("TEST");
            } else
            {
                Util1.DoSomething("TEST");
            }
        }
    }
    public class Utility
    {
        public static void DoSomething(string data)
        {
            //Perform some action
        }
    }
    abstract class Util1 : Utility
    {
        public static new void DoSomething(string data)
        {
            //Perform a different action
        }
    }
