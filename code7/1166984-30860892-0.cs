    protected void ChartOutputButton_Click(object sender, EventArgs e)
    { 
    	//your code to generate chart
    }
    
    protected void CheckBoxList1_SelectedIndexhanged(object sender, EventArgs e)
    {	
    	//you can call ChartOutputButton click event handler here
    	ChartOutputButton_Click(ChartOutputButton, null);
    }
