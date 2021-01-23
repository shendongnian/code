    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		var lblOldSalary = e.Row.FindControl("lblOldSalary") as Label;
    		var lblNewSalary = e.Row.FindControl("lblNewSalary") as Label;
    		
    		//Proper input validation should be done here. i.e. empty string etc
    		var oldSalary =  Convert.ToInt32(lblOldSalary.Text);
    		var newSalary =  Convert.ToInt32(lblNewSalary.Text);
    		
    		if(oldSalary == newSalary){
    			lblOldSalary.ForeColor = Color.FromName("green");
    			lblNewSalary.ForeColor = Color.FromName("green");
    		}
    		else{
    			lblOldSalary.ForeColor = Color.FromName("green");
    			lblNewSalary.ForeColor = Color.FromName("red");
    		}
    	}
    }
