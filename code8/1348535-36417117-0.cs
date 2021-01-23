    bool _updating = false;
    private void txtCelsius_TextChanged(object sender, EventArgs e)
    {
       if (!_updating)
       {
        ///*
        if(string.IsNullOrEmpty(txtCelsius.Text))
        {
            txtFahrenheit.Clear();
            return;
        }
        try
        {
          _updating = true;
          txtFahrenheit.Text = ((double.Parse(txtCelsius.Text)) * 1.8 + 32).ToString();
        //*/
         }
         finally
         {
           _updating = false;
         }
      }
    }
    private void txtFahrenheit_TextChanged_1(object sender, EventArgs e)
    {
       if (!_updating)
       {
        ///*
        if (string.IsNullOrEmpty(txtFahrenheit.Text))
        {
            txtCelsius.Clear();
            return;
        }
        try
        {
        _updating = true;
        txtCelsius.Text = ((double.Parse(txtFahrenheit.Text)) / 1.8 - 32).ToString();
        //*/
       }
       finally
       {
         _updating = false;
       }
      }
    }
