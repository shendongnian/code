    public static void ColorCellText(SharedStringItem si, string TagName, DocumentFormat.OpenXml.Spreadsheet.Color col)
    {
    	var newText = si.InnerText;
    	var startTag = string.Format("<{0}>", TagName);
    	var endTag = string.Format("</{0}>", TagName);
    	if (newText.Contains(startTag))
    	{
    		si.Text.Remove();
    		var lastpos = 0;
    		while (newText.Contains(startTag))
    		{
    			try
    			{
    				var pos1 = newText.IndexOf(startTag);
    				var pos2 = newText.IndexOf(endTag);
    				var txtLen = pos2 - pos1 - 5;
    				var it = string.Concat(newText.Substring(0, pos1), newText.Substring(pos1 + 5, txtLen),
    					newText.Substring(pos2 + 6));
    
    				var run = new Run();
    				var txt = new Text
    				{
    					Text = it.Substring(0, pos1),
    					Space = SpaceProcessingModeValues.Preserve
    				};
    				run.Append(txt);
    				si.Append(run);
    
    				run = new Run();
    				txt = new Text
    				{
    					Text = it.Substring(pos1, txtLen),
    					Space = SpaceProcessingModeValues.Preserve
    				};
    
    				var rp = new RunProperties();
    				
    				rp.Append(col.CloneNode(true));
    				run.RunProperties = rp;
    				run.Append(txt.CloneNode(true));
    				si.Append(run.CloneNode(true));
    
    				newText = newText.Substring(pos2 + 6);
    			}
    			catch(Exception ex)
    			{
    				using (var sw = new StreamWriter(logFile, true))
    				{
    					sw.WriteLine("Error: {0}\r\n{1}", ex.Message, newText);
    				}
    				break;
    			}
    		}
    		if (newText.Length>=0)
    		{
    			var lastrun = new Run();
    			var lasttxt = new Text
    			{
    				Text = newText,
    				Space = SpaceProcessingModeValues.Preserve
    			};
    			lastrun.Append(lasttxt);
    			si.Append(lastrun);
    		}
    	}
    }
