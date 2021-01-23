    using System;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace ConsoleApplication2
    {
        static class Test
        {
            [STAThread]
            static void Main()
            {
                var f = new Form { Text = "Modeless Windows Forms" };
                var t = new Thread(() => Application.Run(f));
                t.Start();
    
                // do some job here then press enter
                Console.WriteLine("Press Enter to Exit");
                var line = Console.ReadLine();
                Console.WriteLine(line);
    
                //say Hi
                if (t.IsAlive) f.Invoke((Action)(() => f.Text = "Hi"));
    
                if (!t.IsAlive) return;
                Console.WriteLine("Close The Window");
                // t.Abort();
                t.Join();
            }
        }
    }
