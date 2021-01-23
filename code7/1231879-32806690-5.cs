    public class HelloWorld : HelloWorldBase
    {
        public void SayHelloExtend()
        {
            var message = "Hello, World Extended!";
            var length = message.Length;
            Console.WriteLine("{1} {0}", message, length);
        }
    }
