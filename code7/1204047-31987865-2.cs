        protected void btnsubmit_OnClick(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            DataRow dr = dt.NewRow();
            dr["Column1"] = TxtNumOfMails.Text;
            dr["Column2"] = TxtRemarksss.Text;
            
            dt.Rows.Add(dr);
            GVDisplay.DataSource = dt;
            GVDisplay.DataBind();
        }
