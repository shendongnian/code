    if(control is TextBox)
    {
      TextBox txtBox = (TextBox)control;
      // Do something with txtBox
      if (string.IsNullOrEmpty(txtBox.Text))
      {
          MessageBox.Show(txtBox.Name + " Can not be empty");
      }
    }
    
    if(control is ComboBox)
    {
      ComboBox combo = (ComboBox)control;
      // Do something with combo
      if (string.IsNullOrEmpty(combo.Text))
      {
          MessageBox.Show(combo.Name + " Can not be empty");
      }
    }
