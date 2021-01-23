    SqlConnection con = new SqlConnection(connectionstring);
    SqlCommand cmd = new SqlCommand ("select fields from database", con);
    con.Open();
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    foreach (DataRow dr in DataSet.Tables[0].Rows){
        Label lbl = new Label();
        lbl.Text = dr["column"].ToString() + ":";
        TextBox txt = new TextBox();
        txt.ID = "txt" + dr["id"].ToString();
    }
