        private const System.Drawing.Color HIGHLIGHT = System.Drawing.Color.Yellow;
        private const System.Drawing.Color NORMAL = System.Drawing.Color.White;
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = DataRepository.highlightRow();
                string[] strInactive = dt.AsEnumerable().Select(row => row.Field<string>("product_id")).ToArray();
                e.Row.BackColor = (e.Row.Cells[0].Text == "TestCondition") ? HIGHLIGHT : NORMAL;
            }
        }
