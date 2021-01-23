    private Task UpdateBar()
        {
            return Task.Factory.StartNew(() =>
            {
                this.Progress = 0;
                for (int i = 0; i < 100; i++)
                {
                    this.Progress = (double)i;
                    this.NotifyPropertyChanged("Progress");
                    Thread.Sleep(30);
                }
            });
        }
