    using DataProcessing;  // no WinForms-stuff
    class ConsoleApp
    {
        static void Main(params int[] args) 
        {
            var r = new Retriever();
            var data = r.GetData();
            foreach(var i in data)
            {
                Console.WriteLine(i);
            }
        }
    }
