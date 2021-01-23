        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
             GridView1.Columns[1].SortExpression = "";   // 0 based, so whatever your column or COLUMNS index are 
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
			GridView1.Columns[1].SortExpression = "MYCOLUMN";  //re-enable clicking
        }
