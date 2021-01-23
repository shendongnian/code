    protected void btnSearch_Click(object sender, EventArgs e) {
    // .....
    bool isBlank = true;
    foreach (DataRow dr in dt.Rows) { // for each row in the data table
    	if (!dr.item("Attachment") == System.DbNull.Value) { // if we find a non null value
    		isBlank = false; // show the column in the gridview
    		break; // then stop checking for nulls
    	}
    }
    GridView1.Columns(9).Visible = !isBlank;
    GridView1.DataBind();
    }
