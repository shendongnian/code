    public MainViewModel()
    {
        Task.Run(() =>
            {
                while (true)
                {
                    ProgressValue++;
                    Thread.Sleep(250);
                }
            });
        }
        public int ProgressValue
        {
            get { return _progressValue; }
            set { _progressValue = value; OnPropertyChanged(); }
        }
    }
