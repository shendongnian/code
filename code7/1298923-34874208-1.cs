    Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
    string S = "Some text";
    int I = 1;
    dispatcher.BeginInvoke(
                            (Action<string, int>)((foo, bar) =>
                            {
                                MessageBox.Show(bar.ToString(), foo);
                                //DoSomeWork(foo);
                                //DoMoreWork(bar); 
                            }), 
                            new object[] { S, I }
                          );
