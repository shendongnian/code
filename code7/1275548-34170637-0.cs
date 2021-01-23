    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    Con = new MySqlConnection(ConnStr);
    DataTable dt = new DataTable();
    try
    {
        Con.Open();
        string getquery = DropDownList1.SelectedValue;
        TextBox1.Text = getquery;
        // a = TextBox2.Text;
        //  TextBox1.Text = a;
        Qry = @"SELECT * FROM finalproject.truckinfo WHERE truckplateno=" + "'" + getquery + "'" + ";";
        MySqlCommand ddlCMD = new MySqlCommand(Qry, Con);
        MySqlDataAdapter msda = new MySqlDataAdapter(ddlCMD);
        msda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        Con.Close();
    }
        catch (Exception ex)
    {
        Response.Write(ex.ToString());
    }
    finally{
       //...
    }
}
