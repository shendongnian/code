    btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
    private void btSubmit_Click(object sender, EventArgs e)
        {
            CaptureBoxes();            
            // send them... somewhere?                        
            MessageBox.Show("Options Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
