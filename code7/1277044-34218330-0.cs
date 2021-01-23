    ` private void FillJurisdictionGrid()
        {
            string Jurisdiction = "Alabama, Alaska, Arizona";
            string IssueDate = "12/10/2015";
            if (Jurisdiction != "")
            {
                grdView.Visible = true;
                string[] jurisdictionData = Jurisdiction.Split(',');
                DataTable dt = new DataTable();
                dt.Columns.Add("Jurisdiction");
                dt.Columns.Add("IssueDate");
                for (int i = 0; i < jurisdictionData.Length; i++)
                {
                    DataRow toInsert = dt.NewRow();
                    dt.Rows.InsertAt(toInsert, i);
                    dt.Rows[i]["Jurisdiction"] = jurisdictionData[i].ToString();
                    dt.Rows[i]["IssueDate"] = IssueDate;
                }
                grdView.DataSource = jurisdictionData;
                grdView.DataBind();
            }
            else
            {
                grdView.Visible = false;
            }
        }`
