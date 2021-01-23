    private void btnPrint_Click(object sender, EventArgs e)
    {
    	printTag.DefaultPageSettings.Landscape = true;
    	PrintPreviewDialog preview = new PrintPreviewDialog();
    
    	// Reset before printing
    	PrintRow = 0;
    	
        preview.Document = printTag;
    	preview.Show();
    }
    
    
    private void printTag_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
    	//Here I set my Fonts, String Formats and Pen Styles
    
        int maxRows = _dtTags.Rows.Count;
        if (maxRows == 0) {
	        return;
        }
    
        PrintRow++;
        e.HasMorePages = PrintRow < _dtTags.Rows.Count;
        int lines = PrintRow - 1;
    	var row = _dtTags.Rows(lines);
        //Pass data from current Row of DataTable to variables which are used to populate the e.Graphic
        jobNum = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Job");
        machInfo = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Job Desc");
        jobNote = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Job Note");
        color = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Color");
        parts = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Parts");
        empName = _dsTags.Tables["Paint Tags"].Rows[lines].Field<string>("Employee");
    
    	//Here my e.Graphic is created, located and filled out
    
    
           
    }
