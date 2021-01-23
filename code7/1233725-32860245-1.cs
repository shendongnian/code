       protected void Page_Load(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            DataRow dr = dt.NewRow();
            DataRow dr1 = dt.NewRow();
            dr["ID"] = 1;
            dr1["ID"] =21;
            DataGrid1.DataSource = dt;
            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            DataGrid1.DataBind();
        }
        protected void DataGrid1__RowDataBound(Object sender, GridViewRowEventArgs e)
        {
         
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("productcode") as LinkButton;
                lnk.Click += new EventHandler(productcode_Click);
            }
        }
         void productcode_Click(object sender, EventArgs e)
        {
            pnlpopup.Visible = true;
            
                
            ModalPopupExtender1.Show();
          
        }
