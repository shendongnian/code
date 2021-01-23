        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label3.ForeColor = System.Drawing.Color.Azure;
            label3.Text = "Request sent...";
            wbsrv.Url = textBox1.Text;
            string response = wbsrv.GenerateRandomSensorData(textBox2.Text);
            await Task.Delay(1000);
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
            await Task.Delay(2000);
            button1.Enabled = true;
        }
