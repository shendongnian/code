    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyObject() { Prop1 = "Hello", };
            Console.WriteLine(obj.Prop1);
            try
            {
                obj.DoWork();
            }
            catch (Exception)
            {
            }
            Console.WriteLine(obj.Prop1);
            /*
            Hello
            World!
            */
        }
    }
    public class MyObject
    {
        public string Prop1 { get; set; }
        public void DoWork()
        {
            this.Prop1 = "World!";
            throw new Exception();
        }
    }
