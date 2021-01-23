    public class MyData
    {
        public MyData(IConsoleMethods consoleMethods) { this.console = consoleMethods; }
        public IConsoleMethods console;
        private string _name;
        public void GetData()
        {
            console.WriteLine("Please Enter your Name(only Alphabet)");
            _name = console.ReadLine();
            console.WriteLine(_name);
        }
    }
