      protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void DataBind()
        {
            DataTable table = ViewState["Data"] as DataTable;
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataRow dr = null;
            DataTable dt = ViewState["Data"] as DataTable;
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Salary", typeof(int)));
                dt.Columns.Add(new DataColumn("Department", typeof(string)));
            }
            dr = dt.NewRow();
            dr["ID"] = txtID.Text;
            dr["Name"] = txtName.Text;
            dr["Salary"] = txtSalary.Text;
            dr["Department"] = txtDepartment.Text;
            dt.Rows.Add(dr);
            ViewState["Data"] = dt;
            DataBind();
        }
