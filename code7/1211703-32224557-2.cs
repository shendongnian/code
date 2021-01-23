    public void SetBackColor(string controlName)
    {
       var controls = this.Controls.Find(controlName, true);
       var control = controls.FirstOrDefault();
       if (control != null)
       {
          var textBox = (TextBox)control;
          textBox.BackColor = Color.Bisque;  // some stuff with finded textbox.
       }
    }
