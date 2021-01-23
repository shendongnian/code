      SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("HyperLink", typeof(string));
                if (ddlstatus.SelectedItem.Text == "Not Done")
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        row["HyperLink"] = "NOT DONE";
                    }
                }
    else if (ddlstatus.SelectedItem.Text == "All")
                {
                    foreach (DataRow row in dt.Rows)
                    {
     string ReviewStatus = dt.Rows[i]["ReviewStatus"].ToString();
                        if (ReviewStatus == "True")
                        {
                            dt.Rows[i]["HyperLink"] = "DONE";
                        }
    else
    {
                        row["HyperLink"] = "NOT DONE";
    }
                    }
                }
                else
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string ReviewStatus = dt.Rows[i]["ReviewStatus"].ToString();
                        if (ReviewStatus == "True")
                        {
                            dt.Rows[i]["HyperLink"] = "DONE";
                        }
                    }
                }
                dt.AcceptChanges();
                grdbatch.DataSource = dt;
                grdbatch.DataBind();
