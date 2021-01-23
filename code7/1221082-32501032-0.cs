     myTextBox.KeyDown += new KeyEventHandler(myTextBox_KeyDown);
     private void myTextBox_KeyDown(object sender, KeyEventArgs e)
     {
          if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
          {
                input = myTextBox.Text;
          }
          else
          {
                input = "";
          }
      }
