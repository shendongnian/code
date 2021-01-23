    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    class Test
    {
        public static void AppRun(object arg)
        {
            Form form = arg as Form;
            Application.Run(form);
        }
    
        [STAThread]
        static void Main(string[] args)
        {
            var t = new Thread(AppRun);
            var f = new Form() { Text = "test" };
            t.Start(f);
    
    
            Console.WriteLine("Press Enter to Exit");
            string line = Console.ReadLine();
            Console.WriteLine(line);
    
    
    
            Console.WriteLine("Close The Window");
            t.Join();
        }
    }
