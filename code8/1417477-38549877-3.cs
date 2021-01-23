    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    class Test
    {
        [STAThread]
        static void Main(string[] args)
        {
            //var finished = false;
            //Action action = delegate()
            //{
            //    new Form().Show();
            //};
            //Task.Factory.StartNew(action);
    
            //while (!finished)
            //{
            //    Console.WriteLine("waiting...");
            //    Thread.Sleep(500);
            //}
            var f = new Form();
            f.Text = "modeless ";
            f.Show();
    
            var f2 = new Form() { Text = "modal " };
    
            Application.Run(f2);
            Console.WriteLine("Bye");
    
        }
    }
