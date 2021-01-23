            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(2000);
                    //LongTimeStuff
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.ApplicationIdle, new Action(() =>
                    {
                        textblock.Text = DateTime.Now.ToString();
                    }));
                }
            });
