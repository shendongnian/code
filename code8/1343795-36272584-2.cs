    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Proper input validation should be done here. i.e. empty string etc
    	    var oldSalary =  Convert.ToInt32(e.Row.Cells[3].Text);
    		var newSalary =  Convert.ToInt32(e.Row.Cells[4].Text);
    		
    		if(oldSalary == oldSalary){
    			e.Row.Cells[3].ForeColor = Color.FromName("green");
    			e.Row.Cells[4].ForeColor = Color.FromName("green");
    		}
    		else{
    			e.Row.Cells[3].ForeColor = Color.FromName("green");
    			e.Row.Cells[4].ForeColor = Color.FromName("red");
    		}
    	}
    }
