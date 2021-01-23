     this.myTextBox.KeyUp += new KeyEventHandler(myTextBox_KeyUp);
     private void myTextBox_KeyUp(object sender, KeyEventArgs e)
     {
          if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
          {
                MessageBox.Show("Hello world");
          }
      }
