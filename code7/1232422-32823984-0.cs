    private void Form1_KeyPress(object sender, KeyPressEventArgs e) 
    {
       if (this.ActiveControl is Button
       && e.KeyChar == (char)Keys.Space) 
       {
          var button = this.ActiveControl;
          button.Enabled = false;
          Application.DoEvents();
          button.Enabled = true;
          button.Focus();
       }
    }
