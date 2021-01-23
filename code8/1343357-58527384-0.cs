     public void GridviewBinding()
        {
            
            DataSet ds = new DataSet();
            string constr = ConfigurationManager.ConnectionStrings["SQLMSDB"].ConnectionString;
            string sql = "select * from tbl_users";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Connection = conn;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds);
                        gridviewcontrol.DataSource = ds;
                        gridviewcontrol.DataBind();
                        ViewState["GridViewBindingData"] = ds.Tables[0];
                    }
                }
            }
        }
        
        
         protected void btn_searching_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_search.Text.Trim().ToString()) || !String.IsNullOrWhiteSpace(txt_search.Text.Trim().ToString()))
            {
                DataTable dt = (DataTable)ViewState["GridViewBindingData"];
                var dataRow = dt.AsEnumerable().Where(x => x.Field<dynamic>("UserName") == txt_search.Text);
                DataTable dt2 = dataRow.CopyToDataTable<DataRow>();
                gridviewcontrol.DataSource = dt2;
                gridviewcontrol.DataBind();
            }
            else
            {
                GridviewBinding();
            }
            
        }
