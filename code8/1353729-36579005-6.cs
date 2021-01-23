    public int Number { get; set; }
    private void UpdateNumber()
    {
            Task.Run(() => 
            {
                System.Timers.Timer timer = new System.Timers.Timer(250);
                timer.Elapsed += (sender, eventArgs) =>
                { 
                    Number++;
                    OnPropertyChanged("Number");//No exceptions, no errors
                };
                timer.Enabled = true;
            });
    }
