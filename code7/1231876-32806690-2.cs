    public abstract class HelloWorldBase
    {
        public void SayHello()
        {
            var message = "Hello, World!";
            var length = message.Length;
            Console.WriteLine("{1} {0}", message, length);
        }
    }
