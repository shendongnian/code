    foreach(Control c in this.Controls) {
       if(c is TextBox) {
          var textbox = c as TextBox;
          if(string.IsNullOrEmpty(textbox.Text)) {
             MessageBox.Show(textbox.Tag.ToString() + " is empty");
          }
       }
    }
