    namespace ConsoleApplication3
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;
    
        internal class Program
        {
            private static readonly ObservableCollection<string> MyList = new ObservableCollection<string>();
    
            private static AutoResetEvent resetEvent = new AutoResetEvent(false);
            private static void Main(string[] args)
            {
                Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            string item = i.ToString("0000");
                            MyList.Add(item);
                            Console.WriteLine(item);
                            Thread.Sleep(1000);
                        }
                    });
    
                MyList.CollectionChanged += (sender, eventArgs) =>
                { if (eventArgs.NewItems.Cast<string>().Any(a => a.Equals("0005"))) resetEvent.Set(); };
                resetEvent.WaitOne();
            }
          
        }
    
    }
