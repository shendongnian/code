    SqlDataAdapter sdaTemp = new SqlDataAdapter();
    DataTable dtTemp = new DataTable();
    MyGlobalVariables.con.Open();
    sdaTemp = new SqlDataAdapter("Select * from Increment where ecode=(select MAX(ecode) from Increment) and UserID='"+MyGlobalVariables.MyUid+"'", MyGlobalVariables.con);
    MyGlobalVariables.con.Close();
    sdaTemp.Fill(dtTemp);
    MyGlobalVariables.dtEmp.Merge(dtTemp);
    MyGlobalVariables.dtEmp.AcceptChanges();
    MyGlobalVariables.bsEmp.MoveLast();
