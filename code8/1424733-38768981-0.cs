    public class Program
    {        public static void Main()
        {
            dynamic dynamicString = "{ \"test\" : \"value\" }";
            string json = "{ \"test\" : \"value\" }";
            var test = new HttpWebRequestBuilder();
                test.SetRequestType();
                //test.SetBody(json); //still works
                test.SetBody(dynamicString); // works also now
                var b = test.Build();
                var s = b.ExtensionMethod();
            Console.WriteLine(s);
        }
    }
