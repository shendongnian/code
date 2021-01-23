    private void PrintButton_Click(object sender, EventArgs e)
    {
    	try
    	{
    		Print(mainDisplay.getCurentPanel());
    	}
    	catch (Exception exp)
    	{
    		MessageBox.Show("Error: \n" + exp.Message);
    	}
    }
    
    private void PrintPreviewButton_Click(object sender, EventArgs e)
    {
    	try
    	{
    		PrintPreview(mainDisplay.getCurentPanel());
    	}
    	catch (Exception exp)
    	{
    		MessageBox.Show("Error: \n" + exp.Message);
    	}
    }
