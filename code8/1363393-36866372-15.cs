    public YourViewModel
    {
        Timer timer;
        public YourViewModel()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;           
        }
        int count = 0;
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(count%2==0)
                FooColor = Brushes.Green;
            else
                FooColor = Brushes.Red;
            count++;
        }
        private Brush fooColor;
        public Brush FooColor           
        {
           get { return fooColor; }
           set
           {
             fooColor = value;
             OnPropertyChanged("FooColor");
           }
        }
    }
