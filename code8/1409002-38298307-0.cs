     private void Form1_Load(object sender, EventArgs e)
     {          
         txtSaveOnClose.Text = Properties.Settings.Default.SavedText;
     }
    
     private void Form1_FormClosing(object sender, FormClosingEventArgs e)
     {
         Properties.Settings.Default.SavedText = txtSaveOnClose.Text;
         Properties.Settings.Default.Save();
     }
