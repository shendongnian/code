    private void bkwParseColors_DoWork(object sender, DoWorkEventArgs e)
    {
    	var docItem = (string) e.Argument;
    	using (var docx = WordprocessingDocument.Open(docItem, false))
    	{
    		var ind = 0;
    		var maxnum = docx.MainDocumentPart.Document.Descendants<Run>().Count();
    		foreach (Run rText in docx.MainDocumentPart.Document.Descendants<Run>())
    		{
    			if (rText.RunProperties != null)
    			{
    				if (rText.RunProperties.Color != null)
    				{
    					ind++;
    					bkwParseColors.ReportProgress(100*ind/maxnum, rText.RunProperties.Color);
    				}
    			}
    		}
    	}
    }
