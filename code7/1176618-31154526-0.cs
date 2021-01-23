     private void stdaq_click (object sender, EventArgs e)
        {
            stopped = false;
            Process();
        }
        
        private void spdaq_Click(object sender, EventArgs e) { stopped = false;}
        
        void Process()
        {
            while(!stopped)
            {
                .. your logic here
            }
        }
