    string cmdText = @"insert into tbl_Transaction_Master 
        (Supplier_ID,Order_Price,Unique_ID,
         Supplier_Name,He_Is_a,Transaction_Date) values 
        (@webid, @price,@sessionid,@user,'WebCust.',getdate()); 
        SELECT SCOPE_IDENTITY()";
    SqlCommand cmd2 = new SqlCommand(cmdText, conn);
    cmd2.Parameters.Add("@webid", SqlDbType.Int).Value = WebUserID 
    cmd2.Parameters.Add("@price", SqlDbType.Decimal).Value = Session["Order_Price"];
    cmd2.Parameters.Add("@sessionid", SqlDbType.Int).Value = Session["WebUserid"];
    cmd2.Parameters.Add("@user", SqlDbType.NVarChar).Value =User;
    int temp = Convert.ToInt32(cmd2.ExecuteScalar());
    Session["order_ID"] = temp;
