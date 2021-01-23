        //initilize look away timer for 10 seconds
        Timer lookAwayTimer = new Timer(interval: 10000);
        //inialize the poll tiomer for 50 ms
        Timer pollTimer = new Timer(interval: 50);
        public ClassConstructor()
        {
            //if 10 seconds expires then show message box
            lookAwayTimer.Elapsed += (s, e) =>
            {
                MessageBox.Show("Looking is set to yes", "Looking Error", MessageBoxButton.OK);
            };
            //enable poll timer
            pollTimer.Enabled = true;
            //check if person is looking. if they are then enable the lookAwayTimer.  If they stop looking
            //then disable the timer
            pollTimer.Elapsed+=(s,e)=>
            {
                LookingAwayResult.Text = frameResult.FaceProperties[FaceProperty.LookingAway].ToString();
                Check = frameResult.FaceProperties[FaceProperty.LookingAway].ToString();
                if(Check=="Yes")
                {
                    lookAwayTimer.Enabled = true;
                }
                else
                {
                    lookAwayTimer.Enabled = false;
                }
            }
        }
