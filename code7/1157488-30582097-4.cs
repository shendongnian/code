    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var f = System.Windows.Forms.Clipboard.GetFileDropList();
            Console.WriteLine(f.Count);
        }
    }
