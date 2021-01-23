    void txtControl_TextChanged(object sender, EventArgs e)
    {
      TextBox txtBox = sender as  TextBox; 
      if(!string.IsNullOrEmpty(txtBox.Text) && txtBox.Text.All(Char.IsDigit))
       {
         //Throw error message
       }
    }
