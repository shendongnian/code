        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }
    protected void Search(object sender, EventArgs e)
    {
        this.BindGrid();
    }
    private void BindGrid()
    {
        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\WebSite1\App_Data\Database.mdb";
        using (OleDbConnection con = new OleDbConnection(constr))
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = con;
                string resultCont = string.Empty;
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    string[] contactNames = txtSearch.Text.Trim().Split(',');
                    foreach (string cont in contactNames)
                    {
                        if (!string.IsNullOrEmpty(cont))
                        {
                            resultCont = resultCont + ",'" + cont + "'";
                        }
                    }
                    resultCont = resultCont.Remove(0, 1);
                    cmd.CommandText = "SELECT * FROM myTable WHERE Docnum IN (" + resultCont + ")";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM myTable";
                }
                DataTable dt = new DataTable();
                using (OleDbDataAdapter sda = new OleDbDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    gvCustomers.DataSource = dt;
                    gvCustomers.DataBind();
                }
            }
        }
    }
