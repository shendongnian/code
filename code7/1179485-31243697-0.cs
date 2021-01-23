    class MyWriter : TextWriter
    {
        private TextWriter originalOut;
        public MyWriter()
        {
            originalOut = Console.Out;
        }
        public override Encoding Encoding
        {
            get { return new System.Text.ASCIIEncoding(); }
        }
        public override void WriteLine(string message)
        {
            originalOut.WriteLine(CheckMySerie(message));
        }
        public override void Write(string message)
        {
            originalOut.Write(CheckMySerie(message));
        }
        private string CheckMySerie(string message)
        {
            if (message.Contains("MySerie"))
                return "My Serie has been found\n" + message;
            else
                return message;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetOut(new MyWriter());
            Console.WriteLine("test 1 2 3");
            Console.WriteLine("test MySerie 2 3");
            Console.ReadKey();
        }
    }
