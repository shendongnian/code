    void AllTextBox(System.Windows.Forms.Control.ControlCollection ctrls)
        {
           foreach (Control ctrl in ctrls)
           {
              if (ctrl is TextBox)
                  {
                     if (ctrl.Name == "textBox1")
                     {
                        // do your stuf with textbox
                     }
                     
                  }
            }
        }
