    for (int obs = 0; obs < loanCNT; obs++)
                    {
                        line = sr.ReadLine();
                        Processing.Run(new Loan(), line);
                        progressBarValue += 1;
                        Dispatcher.Invoke(updatePbDelegate,System.Windows.Threading.DispatcherPriority.Background, new object[] { ProgressBar.ValueProperty, progressBarValue });
                    }
