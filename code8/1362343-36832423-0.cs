    public class Wakeup : World
    {
        public void MethodA(string strValue)
        {
            Console.WriteLine(strValue);
        }
    }
    public class Hello : World
    {
        public void MethodB()
        {
            Wakeup p = new Wakeup();
            p.MethodA("Hello, World");
        }
    }
