       Thread thread;
                bool flag = false;
                public MainWindow()
                {
                    InitializeComponent();
                    thread = new Thread(new ThreadStart(search));
                    thread.Start();
                }
    
                private void textBoxInput_TextChanged(object sender, TextChangedEventArgs e)
                {
                    if(flag)
                       return;
                    flag = true;
                }
    
                private void search()
                {
                    while(true)
                    {
                        if(flag)
                        {
                            string result = search(textBoxInput.Text);
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                textBoxOutput.Text = result;
                            }));
                            flag = false;
                        }
                        Thread.Sleep(200);
                    }
                }
