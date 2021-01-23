    using System;
    using System.Windows.Forms;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Test
    {    
        static void Main()
        {
            var form = new Form();
            form.Load += async (sender, args) =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                await Task.FromResult(10).ConfigureAwait(false);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                await Task.Delay(1000).ConfigureAwait(false);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            };
            Application.Run(form);
        }
    }
