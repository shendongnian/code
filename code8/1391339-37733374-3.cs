    object param1 = DBNull.Value;
    object param2 = DBNull.Value;
    object param3 = DBNull.Value;
    
    if(!String.IsNullOrEmpty(TextBox1.Text))
        param1 = TextBox1.Text;
    
    if(!String.IsNullOrEmpty(TextBox2.Text))
        param2 = TextBox2.Text;
    
    if(ComboBox5.SelectedValue != null)
        param3 = TextBox1.Text;
    
    cmd.Parameters.AddWithValue("@varchar1", param1 );
    cmd.Parameters.AddWithValue("@varchar2", param2 );
    cmd.Parameters.AddWithValue("@varchar3", param3 );
