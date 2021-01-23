    namespace ConsoleApplication3
    {
        using System;
        using System.Collections.ObjectModel;
        using System.Linq;
        using System.Threading;
        using System.Threading.Tasks;
    
        internal class Program
        {
            #region Static Fields
    
            private static readonly CancellationTokenSource Cts = new CancellationTokenSource();
    
            private static readonly ObservableCollection<string> MyList = new ObservableCollection<string>();
    
            private static readonly AutoResetEvent ResetEvent = new AutoResetEvent(false);
    
            #endregion
    
            #region Methods
    
            private static void Main(string[] args)
            {
                Task task = Task.Factory.StartNew(
                    () =>
                    {
                        for (int i = 0; i < 10 && !Cts.IsCancellationRequested; i++)
                        {
                            string item = i.ToString("0000");
                            MyList.Add(item);
                            Console.WriteLine(item);
                            Thread.Sleep(100);
                        }
                    },
                    Cts.Token);
                Task finish = task.ContinueWith(antecedent => { Console.WriteLine("Task finished. Status {0}", antecedent.Status); });
                MyList.CollectionChanged += (sender, eventArgs) =>
                {
                    if (eventArgs.NewItems.Cast<string>().Any(a => a.Equals("0005")))
                    {
                        Cts.Cancel();
                        ResetEvent.Set();
                    }
                };
                ResetEvent.WaitOne();
                Task.WaitAll(finish);
            }
    
            #endregion
        }
    }
