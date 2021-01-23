    public void GridView1_OnDataBound(object sender, EventArgs e)
    {
    	DataTable dt = new DataTable();
    	DataRow dr;
    	dt.Columns.Add(new DataColumn("DATE"));
    	dt.Columns.Add(new DataColumn("CODE"));
    	dt.Columns.Add(new DataColumn("PERSON_NAME"));
    	dt.Columns.Add(new DataColumn("STATUS"));
    	dt.Columns.Add(new DataColumn("HOBBIES"));
    	dt.Columns.Add(new DataColumn("SCORE"));
    	dt.Columns.Add(new DataColumn("ITEM"));
    	dt.Columns.Add(new DataColumn("QUANTITY"));
    	dt.Columns.Add(new DataColumn("TYPE"));
    	dt.Columns.Add(new DataColumn("RATING"));
    	dt.Columns.Add(new DataColumn("PRICE"));
    	foreach (GridViewRow gvr in GridView1.Rows)
    	{
    		if (e.Row.RowType == DataControlRowType.DataRow)
    		{
    			if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS")) == "Regular")
    			{
    				dr = dt.NewRow();
    				dr["DATE"] = e.Row.Cells[0].Text;
    				dr["CODE"] = e.Row.Cells[1].Text;
    				dr["PERSON_NAME"] = e.Row.Cells[2].Text;
    				dr["STATUS"] = e.Row.Cells[3].Text;
    				dr["HOBBIES"] = e.Row.Cells[4].Text;
    				dr["SCORE"] = e.Row.Cells[5].Text;
    				dr["ITEM"] = e.Row.Cells[6].Text;
    				dr["QUANTITY"] = e.Row.Cells[7].Text;
    				dr["TYPE"] = e.Row.Cells[8].Text;
    				dr["RATING"] = e.Row.Cells[9].Text;
    				dr["PRICE"] = e.Row.Cells[10].Text;
    				dt.Rows.Add(dr);
    				
    			}
    		}
    	}
    	GridView2.DataSource = dt;
    	GridView2.DataBind();
    }
