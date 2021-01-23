        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            else 
            {
                if (SecondsPassed(5))
                {
                   //execute
                }
            } 
        }
    
        private DateTime _lastCallTime = new DateTime();
        private bool SecondsPassed(double seconds)
        {
            // calculate time difference
            var timeSpan = new TimeSpan(DateTime.Now.Ticks - _lastCallTime.Ticks);
            // reset timing
            _lastCallTime = DateTime.Now;
            if (timeSpan.TotalSeconds > seconds)
            {
                return true;
            }
            return false;
        }
