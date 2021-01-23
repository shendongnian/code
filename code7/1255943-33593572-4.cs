    var maxnum = doc.Words.Count;
    var ind = 0;
    foreach (Word.Range wd in doc.Content.Words)
    {
    	if (!string.IsNullOrEmpty(wd.Text.Trim('\r', '\n', ' ')))
    	{
    		ind++;
    		var rgb = RgbColorRetriever.GetRGBColor(wd.Font.Color, doc);
    		bkwParseColors.ReportProgress(100 * ind / maxnum, rgb);   
    		
    	}
    }
