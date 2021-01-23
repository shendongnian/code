    byte[] imgByte = null;
    SqlCommand cmd = new SqlCommand("SELECT Image FROM tableName",yourConnectionStringHere);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.fill(ds);
    foreach(DataRow dr in ds.Tables[0].Rows)
    {
      string str = Convert.ToBase64String(imgByte);
      imageIDtagName.Src = "data:Image/png;base64," + str;
    }
