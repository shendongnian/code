      public void AppendKeyCode(Keys keyCode) {
        listBox1.Items.Add(keyCode);
    
        File.AppendAllText(@"d:\Prova.txt", keyCode.ToString());
      }
    
      // Please, notice "private": do not expose such methods
      private void Form2_KeyUp(object sender, KeyEventArgs e) {
        AppendKeyCode(e.KeyCode);
      }
