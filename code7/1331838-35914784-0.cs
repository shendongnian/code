     private void input_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        { 
            //Check here tab press or not
            if (e.KeyCode == Keys.Tab)
            {
               //our code here
            }
            //Check for the Shift Key as well
            if (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.Tab) {
               
            }
        }
