       SqlConnection conn = new SqlConnection("Data Source = 'PAULO'; Initial Catalog=ShoppingCartDB;Integrated Security =True");
    conn.Open();
    string checkuser = "select count(*) from UserData where Username = '" + txtUser.Text + "'";
    SqlCommand scm = new SqlCommand(checkuser, conn);
    SqlDataAdapter da=new SqlDataAdapter(scm); 
    DataSet ds=new DataSet();
    da.Fill(ds);
    conn.Close();
    string userdata="";
    foreach (DataRow row in ds.Tables[0].Rows)
    {
       for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
        {
         userdata+=","+row[i].ToString();
        }
    }
    userdata=userdata.TrimStart(',');
    Session["username"]= userdata;
