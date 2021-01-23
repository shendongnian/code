    protected override void OnKeyDown(object sender, KeyEventArgs e)
    {
         if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
         {
               // Your logic to read clipboard content and check length.;
         }     
    }
    
    private void Form1_MouseClick(object sender, MouseEventArgs e)
    { 
         if (e.Button == System.Windows.Forms.MouseButtons.Right)
         {
              // You logic goes here.
         }
    }
