    public class Program
    {
        public static bool __bDebug = false;
        static void Main()
        {
            //code to get settings from your Xml File
            __bDebug = ValueFromXmlFile;
        }
    }
    public class A
    {
        public A()
        {
            //You can access Program.__bDebug from anywhere in your application
            if (Program.__bDebug == true)
            {
            }
        }
    }
