                System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < A.Length - 1; i++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Lbl.Dispatcher.Invoke(() => { Lbl.Content = i + " : " + A[i]; });
                    }
                });
