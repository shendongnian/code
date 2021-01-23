        protected void ApproveLoanButton_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)DetailsSqlDataSource.Select(DataSourceSelectArguments.Empty);
            dv.AllowEdit = true;
            using (var dt = dv.ToTable())
            {
                var oldValue = dt.Rows[0]["IsApproved"].ToString();
                if (-1 < SaveApproved((int)dt.Rows[0]["ID"], true))
                {
                    dt.Rows[0]["IsApproved"] = true;
                    var newValue = dt.Rows[0]["IsApproved"].ToString();
                    dt.AcceptChanges();
                    DetailsSqlDataSource = GetTable();
                    GridView1.DataBind();
                    DetailsView1.DataBind();
                }
            }
        }
