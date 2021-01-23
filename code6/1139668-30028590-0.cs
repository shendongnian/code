        bool isManualFire = true;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Clear isManualFire flag for programatical changes
            isManualFire = false;
            
            //Do programatic changes on toolStripComboBox1
            
            //Set it back to save manual firings
            isManualFire = true;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isManualFire)
            {
                //Do something
            }
        }
