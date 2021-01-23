    private string _ImageURI = "";// add the path of your image in the quotes
            public string ImageURI { get { return _ImageURI; } set { _ImageURI = value; NotifyPropertyChanged(); } }
        public void SlideShow()
        {
            DispatcherTimer DT = new DispatcherTimer();
            DT.Tick += DT_Tick;
            DT.Interval = new TimeSpan(0, 0, 1);
            DT.Start();
        }
        private void DT_Tick(object sender, EventArgs e)
        {
            // Change your image uri here 'ImageURI'
        }
