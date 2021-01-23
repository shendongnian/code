    //In CheckBoxList1Bind() Method
    ListItem item2 = new ListItem();
    item.Value = sdr["AccountID"].ToString();
     //In Generate() Method
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.CommandText = "Update_Account_Table";
     foreach(ListItem item2 in CheckBoxList1.Items)
     {
        if(item2.Selected)
        {
        //handling parameters in loop.
          cmd.Parameters["@SeqNum"].Value = amount.Text;
          cmd.Parameters["@SeqDate"].Value = DateTime.ParseExact(datepicker.Text, "mmddyyyy", CultureInfo.InvariantCulture);
          cmd.Parameters["@Account_ID"].item2.Value;
          cmd.ExecuteNonQuery();
        
           try
           {
               conn.Open();
               cmd.ExecuteNonQuery();
           }
           catch (SqlException ex)
           {
              MessageBox.Show(ex.Message);
           }
           finally
           {
              conn.Close();
           }
        }
     }
