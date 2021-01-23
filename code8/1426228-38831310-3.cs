        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("proj_title", typeof(string)),
                            new DataColumn("Count",typeof(int))});
            dt.Rows.Add(1, "SQl", 2);
            dt.Rows.Add(2, "C#", 5);
            g9.DataSource = dt;
            g9.DataBind();
        }
        protected void g9_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // i dont use this...
            }
        }
        // Create this function and call this to in your gridview
        // see above in design page
        public string ConvertResult(string strCount)
        {
            string strResult = "";
            int iValue = Convert.ToInt32(strCount);
            if (iValue < 2)
                strResult = "Bad";
            if (iValue == 2)
                strResult = "Poor";
            if (iValue == 5)
                strResult = "great";
            return strResult;
        }
