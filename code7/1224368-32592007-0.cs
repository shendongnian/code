     public MainWindow()
        {
            InitializeComponent();
            Task t = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Executing long running thread");
                int i = 0;
                while (true)
                {
                    //update textbox on UI
                    Dispatcher.Invoke(() => textBox.Text = i.ToString());
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    i++;
                }
            }, TaskCreationOptions.LongRunning);
        }
