    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    class Test
    {
    
        [STAThread]
        static void Main(string[] args)
        {
            var f = new Form() { Text = "Modeless Windows Forms" };
            var t = new Thread((form) => Application.Run((Form)form));
            t.Start(f);
    
            Console.WriteLine("Press Enter to Exit");
            string line = Console.ReadLine();
            Console.WriteLine(line);
    
            if (t.IsAlive) Console.WriteLine("Close The Window");
            //t.Abort();
            t.Join();
        }
    }
