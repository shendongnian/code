    public Form1()
            {
                this.StartPosition =FormStartPosition.Manual;
                InitializeComponent();
    
                Screen sndSc = Screen.AllScreens[1];
              
                if (sndSc.Primary)
                {
                    sndSc = Screen.AllScreens[0];            
                }
                this.Height = sndSc.WorkingArea.Height;
                this.Width = sndSc.WorkingArea.Width; 
                this.Location = sndSc.WorkingArea.Location;   
            }
 
