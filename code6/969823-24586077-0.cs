    if(Request[Id]!=null)
    {
        string demo = Request[Id].ToString();
        SqlConnection con = new SqlConnection("Your connection String");
        SqlCommand cmd = new SqlCommand("Select * from Your table where name = '"+demo+"'")
        SqlDataReader dr = cmd.ExecuteReader();
        while(dr.Read())
        {
           DetailsView1.Rows[0].Cells[2].Text = dr.GetString(0);//Your Product goes here
           // Proceed the same for your remaining entries 
        }
    }
