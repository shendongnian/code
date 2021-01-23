        OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["OLEDB"].ToString());
        OleDbDataAdapter datapter;
        DataSet dset;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string queryGV = "SELECT * FROM table time > current_timestamp -20  AND EQUIPMENT != 'sth' ORDER BY time DESC";
                string queryDLL1 = "SELECT DISTINCT EQUIPMENT FROM table ORDER BY EQUIPMENT";
                OleDbCommand cmdGV = new OleDbCommand(queryGV, conn);
                OleDbCommand cmdDLL1 = new OleDbCommand(queryDLL1, conn);
                DataSet ds = new DataSet();
                DataSet DLL1 = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmdGV);
                OleDbDataAdapter daDLL1 = new OleDbDataAdapter(cmdDLL1);
                da.Fill(ds);
                daDLL1.Fill(DLL1);
                GridView1.DataSource = ds;
                DropDownList1.DataSource = DLL1;
                GridView1.DataBind();
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Teil", "0"));
                //GridViewBind();
                conn.Close();
            }
        }
        protected void OnSelectedIndexChanged_DropDownList1(object sender, EventArgs e)
        {
            string valtxt = DropDownList1.SelectedItem.ToString();
            if (DropDownList1.SelectedIndex != 0)
            {
                GridViewBind();
            }
        }
        private void GridViewBind()
        {
            string query = "select equipment, primekey from PI_EVENT_TABLE where primekey=" + DropDownList1.SelectedValue.ToString();
            conn.Open();
            datapter = new OleDbDataAdapter(query, conn);
            dset = new DataSet();
            datapter.Fill(dset);
            GridView1.DataSource = dset.Tables[0];
            GridView1.DataBind();
            conn.Close();
        }
