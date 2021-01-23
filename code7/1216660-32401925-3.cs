            InitializeComponent();
            //this.WindowStartupLocation = WindowStartupLocation.CenterScreen; //start the window at the centre of the screen
            DataContext = this;
            pipe.Data += new PipeLink.PipeService.DataIsReady(DataBeingRecieved);
            if (pipe.ServiceOn() == false)
                MessageBox.Show(pipe.error.Message);
            label1.Content = "Listening to Pipe: " + pipe.CurrentPipeName + Environment.NewLine;
        }
        void DataBeingRecieved(int data)
        {
            Dispatcher.Invoke(new Action(delegate()
            {
                label1.Content += string.Join(Environment.NewLine, data);
                label1.Content += Environment.NewLine;
            }));
        }
