    protected void gen_barcode(object sender, EventArgs e)
    {
        DateTime date_picker = datepicker.Value;
        int intAmount; // get the int value for the amount here...
        String imgName; // get the image name here...
        SqlConnection conn = new SqlConnection(GetConnectionString());
    
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
    
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "barcode_insert"
    
        cmd.Parameters.Add("@Seq_Num", SqlDbType.Int);
        cmd.Parameters.Add("@date", SqlDbType.DateTime);
        cmd.Parameters.Add("@ImageName" , SqlDbType.NVarChar);
        cmd.Parameters["@Seq_Num"].Value = intAmount;
        cmd.Parameters["@date"].Value = date_picker;
        cmd.Parameters["@ImageName"].Value = imgName;
        
        if (CheckBox_Code.Checked)
        {
              //put this somewhere else since it isn't related in function
        }
    
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
 
