        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(state)
            {
                case Curtain.Up:
                    this.Opacity = e.ProgressPercentage / 100.0;
                    break;
                case Curtain.Down:
                    this.Opacity = (100 - e.ProgressPercentage) / 100.0;
                    break;
            }
        }
