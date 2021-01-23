    private void bkwParseColors_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	progressBar1.Value = e.ProgressPercentage;
    
    	var color = (DocumentFormat.OpenXml.Wordprocessing.Color)e.UserState;
    	var thema = "";
    	if (color.ThemeColor!=null)
    		thema = color.ThemeColor.Value.ToString();
    	
    	var farbe = color.Val.Value; //hex RGB
    	var drin = lstColors.FindItemWithText(farbe);
    	if(drin==null)
    	{
    		var li = new myListItem
    		{
    			Design = thema,
    			Farbe = farbe,
    			Text = farbe,
    			BackColor = ColorTranslator.FromHtml("#" + farbe)
    		};
    		lstColors.Items.Add(li);
    	}
    }
