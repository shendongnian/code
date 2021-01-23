    //your code
    //SqlDataAdapter sda2 = new SqlDataAdapter();//no need
    SqlCommand cmd2 = new SqlCommand("SELECT toa_receipt FROM toa_CreditCardStatement WHERE id = @id", con2);
    //It is very insecure to concatenate value into SQL string
    //cmd2.Connection = con2;
    //Use parameter instead
    cmd2.Parameters.Add("@id",DbType.VarChar).Value = id;
    con2.Open();
    using(SqlDataReader r = cmd2.ExecuteReader()){
       if(r.Read()){
          ddlReceipt.SelectedValue = (string)r["toa_receipt"];
       }
    r.Close();
    }
    con2.Close();
