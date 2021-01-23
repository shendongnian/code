     comboBox2.KeyDown += comboBox2_KeyDown;
     comboBox2.ContextMenu = new ContextMenu();   //diable right click
     void comboBox2_KeyDown(object sender, KeyEventArgs e)
     {
          if (!(e.Control && e.KeyCode == Keys.C))
          {
               e.SuppressKeyPress = true;
          }
     }
