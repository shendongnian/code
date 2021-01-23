    void AllTextBox(System.Windows.Forms.Control.ControlCollection ctrls)
        {
           foreach (Control ctrl in ctrls)
           {
              if (ctrl is TextBox)
                  {
                     // do your stuf with textbox
                  }
           }
        }
