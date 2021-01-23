    protected void Page_Load(object sender, EventArgs e)
    {
    try
    {
        //string url = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=& Server.MapPath(northWind.mdb.accdb)";
        //string url = "Provider=Microsoft.Jet.OLEDB.4.0;DataSource=& northWind.mdb.accdb;";
        string url = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:/WebSite2/northWind.mdb.accdb;Persist Security Info=False;";
        OleDbConnection conn = new OleDbConnection(url);
        conn.Open();
       string query = "INSERT INTO Customer Values('"+fname.Text+"','"+lname.Text+"','"+phone.Text+"','"+mail.Text+"','"+password.Text+"','"+fname.Text+"')";
        OleDbDataAdapter adp = new OleDbDataAdapter(query, conn);
        DataSet ds = new DataSet();
        ds.AcceptChanges();
        adp.Fill(ds,"Customer");
        adp.Update(ds);
        DataView dv = new DataView(ds.Tables["Customer"]);
        DataGrid dgv = new DataGrid();
        dgv.DataSource = dv;
       // dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.DataBind();
        Response.Redirect("main.aspxs");
        conn.Close();
    }
    catch (Exception Exp)
    {
        System.Console.WriteLine("Error Found in Main page process");
        throw Exp;
    }
}
