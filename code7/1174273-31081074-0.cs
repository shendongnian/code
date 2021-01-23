        bool alertIsOFF = false; // Global variable
        
        private void btnFinish_Click(object sender, EventArgs e)
        {
            Clock.Enabled = false; //turn off Clock (and reliant Timers)
            string finishmsg = "Save monitoring data and end monitoring"; //message displayed to user
            string finishTitle = "End Monitoring Confirmation"; //title of the message box
            DialogResult finishRes = MessageBox.Show(finishmsg, finishTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question); //display messageBox and options
            if (finishRes == DialogResult.Yes)
            {
                saveFileFooter(); //append the footer template and associated variable values to the text file
                saveBPChartImage();
                MessageBox.Show("The vitals data recorded in this program has been saved to the file: " +
                                fileName + //file name specified
                                "\nThe recovery data fields can now be filled in"); //give user file address and direct to completing recovery data
                enableRecoveryData();
        
                intervalCounter.Stop();
                alertIsOff = true;
                StopWatch = Stopwatch.StartNew();
            }
            else
            {
                Clock.Enabled = true;
                intervalCounter.Enabled = true;
            }
        }
    
        //initialiseIntervalCounter sub-functions
        private void intervalAlert(object source, ElapsedEventArgs e)         //intervalCounter EventHandler definition
        {
            if (!alertIsOff)
            {
				Clock.Enabled = false;
				string alertTitle = "Interval Alert";
				string alertMessage = "The 5 minute interval has been reached, enter the current readings";
				clearInput();
				DialogResult okRes = MessageBox.Show(alertMessage, alertTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				if (okRes == DialogResult.OK)
				{
					Clock.Enabled = true;
				}
            }
            
        }
        //end initialiseIntervalCounter sub-functions
