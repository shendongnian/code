    private void bkwEinblenden_DoWork(object sender, DoWorkEventArgs e)
    {
    	var args = (List<object>) e.Argument;
    	var pfad = (string) args[0];
    	var color = (myListItem) args[1];
    	using (var docx = WordprocessingDocument.Open(pfad, true))
    	{
    		var ind = 0;
    		var maxnum = docx.MainDocumentPart.Document.Descendants<Run>().Count();
    		foreach (Run rText in docx.MainDocumentPart.Document.Descendants<Run>())
    		{
    			bkwEinblenden.ReportProgress(100*ind/maxnum);
    			var vanish = new Vanish() { Val = OnOffValue.FromBoolean(true) };
    			if (rText.RunProperties == null)
    			{
    				var runProp = new RunProperties {Vanish = vanish};
    				rText.RunProperties = runProp;
    			}
    			else
    			{
    				if (rText.RunProperties.Vanish == null)
    					rText.RunProperties.Vanish = vanish;
    				else
    				{
    					rText.RunProperties.Vanish.Val = OnOffValue.FromBoolean(true);
    				}
    			}
    			if (rText.RunProperties.Color != null)
    			{
    				if (rText.RunProperties.Color.Val == color.Farbe)
    				{
    					if (!string.IsNullOrEmpty(color.Design))
    					{
    						if (rText.RunProperties.Color.ThemeColor.Value.ToString() == color.Design)
    						{
    							rText.RunProperties.Vanish.Val = OnOffValue.FromBoolean(false);
    						}
    					}
    					else
    					{
    						rText.RunProperties.Vanish.Val = OnOffValue.FromBoolean(false);
    					}
    				}
    			}
    		}
    	}
    }
