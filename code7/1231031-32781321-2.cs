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
    		if (gvr.Cells[3].Text == "Regular")
            {
                dr = dt.NewRow();
                dr["DATE"] = gvr.Cells[0].Text;
                dr["CODE"] = gvr.Cells[1].Text;
                dr["PERSON_NAME"] = gvr.Cells[2].Text;
                dr["STATUS"] = gvr.Cells[3].Text;
                dr["HOBBIES"] = gvr.Cells[4].Text;
                dr["SCORE"] = gvr.Cells[5].Text;
                dr["ITEM"] = gvr.Cells[6].Text;
                dr["QUANTITY"] = gvr.Cells[7].Text;
                dr["TYPE"] = gvr.Cells[8].Text;
                dr["RATING"] = gvr.Cells[9].Text;
                dr["PRICE"] = gvr.Cells[10].Text;
                dt.Rows.Add(dr);
            }
    	}
    	GridView2.DataSource = dt;
    	GridView2.DataBind();
    }
