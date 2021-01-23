     private void usereditFieldControl_Click(object sender, EventArgs e)
        {            
            EditFieldControl editFieldControl = (EditFieldControl)sender;           
            editFieldControl.KeyDown += new KeyEventHandler(Key_pressed);
        }
    private void Key_pressed(object sender, KeyEventArgs e)
        {
            EditFieldControl editFieldControl = (EditFieldControl)sender;
                if (e.KeyCode == Keys.Delete)
                {
                    //Find control
                     for (int i = 0; i < editFieldControl.Parent.Controls.Count(); i++) {
                     if (editFieldControl.Parent.Controls[i].Name == editFieldControl.Name) {
                     //Unhook events to prevent memory leaks
                   editFieldControl.KeyDown -= new KeyEventHandler(Key_pressed);
                     //Remove control from collection 
                    editFieldControl.Parent.Controls.RemoveAt[i];
                     break;
                }         
             }
          //repaint 
          this.Invalidate();
           }
        }
