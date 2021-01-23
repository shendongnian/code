       private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
    
            label3.ForeColor = System.Drawing.Color.Azure;
            label3.Text = "Request sent...";
            wbsrv.Url = textBox1.Text;
            string response = wbsrv.GenerateRandomSensorData(textBox2.Text);
            // Custom Task Class 
            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(AfteDelay); 
    
        }
       private void AfterDelay(){
        
                label3.Text = response;
                if (label3.Text.Contains('7'))
                { 
                    label3.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    label3.Text = "Error";
                    label3.ForeColor = System.Drawing.Color.Red;
                }
        
                if (lbl_hid == true)
                {
                    label3.Show();
                    lbl_hid = false;
                }
        
                button1.Enabled = true;
       }
