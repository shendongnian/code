    void txtControl_TextChanged(object sender, EventArgs e)
    {
      if(!string.IsNullOrEmpty(txtControl.Text) && txtControl.Text.All(Char.IsDigit))
       {
         //Throw error message
       }
    }
