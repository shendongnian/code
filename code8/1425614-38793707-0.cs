    protected void gen_barcode(object sender, EventArgs e)
    {
        DateTime date_picker = datepicker.Value;
        SqlConnection conn = new SqlConnection(GetConnectionString());
    
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
    
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "barcode_insert"
    
        cmd.Parameters.AddWithValue("@Seq_Num", amount.Text);
        cmd.Parameters.AddWithValue("@date", date_picker);
        cmd.Parameters.AddWithValue("@ImageName", CheckBox.Checked);
    
        if (CheckBox_Code.Checked)
        {
              //put this somewhere else since it isn't related in function
        }
    
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
 
