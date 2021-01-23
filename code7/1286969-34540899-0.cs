       DataTable dt = bLStatus.GetStatusDetail();
                if (dt != null && dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "Description ASC";
                    DataTable dt2 = dt.DefaultView.ToTable();
                    DataRow row1 = dt2.NewRow();
                    row1["Description"] = "All";
                    dt2.Rows.InsertAt(row1, 0);
                    cmbCurrentStatus.DataSource = dt2;
                    cmbCurrentStatus.ValueMember = "Description";
                    cmbCurrentStatus.DisplayMember = "Description";
                }
