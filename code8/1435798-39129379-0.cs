    for(i = 0; i <= CheckBoxList1.Items.Count - 1; i++)
    {
        if(BatchCodeList.Items[i].Selected)
        {
        //handling parameters in loop.
          cmd.Parameters["@SeqNum"].Value = amount.Text;
          cmd.Parameters["@SeqDate"].Value = DateTime.ParseExact(datepicker.Text, "mmddyyyy", CultureInfo.InvariantCulture);
          cmd.Parameters["@Account_ID"].CheckBoxList1.SelectedValue;
         
     
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
