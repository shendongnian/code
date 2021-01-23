           protected void ButtonOk_Click(object sender, EventArgs e)
        {
            string strDeleteRecord = (string)Session["OrgDeleteRecord"];
            int intOrgRowIndex = (int)Session["OrgRowIndex"];
            DataTable dt = new DataTable();
            dt = (DataTable)Session["OrgDataSet"];
            DataRow[] rows;
            rows =  dt.Select("OrgID='" + strDeleteRecord + "'");
            foreach (DataRow row in rows)
                dt.Rows.Remove(row);
            //here you can call your LoadGridData() After Delete;
            this.LoadGridData();
            Session["OrgDataSet"] = dt;
        }
