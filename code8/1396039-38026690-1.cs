       public Window()
                {
                          InitializeComponent();
                      DispatcherTimer timer = new DispatcherTimer();
                        //timer.Interval = new TimeSpan(0, 0, 2);
                        timer.Tick += ((sender, e) =>
                        {
                            Conversation.Height += 10;
                           
                                Sviewer.ScrollToBottom();
                             
                        });
                        timer.Start();
        }
