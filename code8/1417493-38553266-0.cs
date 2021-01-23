    class Program
    {
    
        public static void ThreadProc(object arg)
        {
            Form form = arg as Form;
            Application.Run(form);
        }
    
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new Form() { Text = "test" };
    
            Thread t = new Thread(ThreadProc);
            t.Start(form);
            string line = Console.ReadLine();
            Console.WriteLine(line);
    
            form.Close();
        }
    }
