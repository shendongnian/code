        public void SetTimer ()
        {
            timer.Interval = 1000;
            timer.Elapsed += (sender, e) => UpdateCounter ();
            timer.Start ();
        }
