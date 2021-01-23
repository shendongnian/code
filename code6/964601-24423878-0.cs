    public String UserNameCheck(String alias) 
    {
    String returnValue = String.Empty;
    SqlCommand cmd = null;
    SqlDataAdapter adapter = null;
    DataTable dt = null;
    try
    {
    OpenCnn();
    cmd =new SqlCommand();
    cmd.Connection = con;
    cmd.CommandText = "Select count(*) from cntc_employee where emp_alias=@alias"; 
    cmd,Parameter.Clear();
    cmd.Parameter.AddWithValue("@alias", alias);
    dt = new DataTable();
    adapter = new SqlDataAdapter(cmd);
    adapter.Fill(dt);
    if(dt.Rows.Count > 0)
    returnValue = "userNameIsExist";
    else
    returnValue = "userIsNotFound";
    } 
    catch (Exception ex) 
    {
    throw ex; 
    } 
    finally 
    { 
    if(dt != null) { dt.Dispose(); dt = null; }
    if(adapter != null) { adapter.Dispose(); adapter null; }
    if(cmd != null) { cmd.Parameter.Clear(); cmd.Dispose(); cmd = null; }
    CloseCnn();
    }
    return returnValue;
    }
