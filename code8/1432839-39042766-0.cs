    var xlsx = SpreadsheetDocument.Open(xlsPath, true);
    var contents = xlsx.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
    foreach (SharedStringItem si in contents.SharedStringTable.Elements<SharedStringItem>())
    {
    	while(si.InnerText.Contains("<del>"))
    	{
    		var pos1 = si.InnerText.IndexOf("<del>");
    		var pos2 = si.InnerText.IndexOf("</del>");
    		var txtLen = pos2 - pos1 -5;
    		var it = si.InnerText;
    		var newText = string.Concat(it.Substring(0, pos1), it.Substring(pos1 + 4, txtLen),
    			it.Substring(pos1 + txtLen));
    		si.Text.Remove();
    
    		var run = new Run();
    		var txt = new Text
    		{
    			Text = newText.Substring(0, pos1),
    			Space = SpaceProcessingModeValues.Preserve
    		};
    		run.Append(txt);
    		si.Append(run);
    
    		run = new Run();
    		txt = new Text
    		{
    			Text = newText.Substring(pos1, txtLen),
    			Space = SpaceProcessingModeValues.Preserve
    		};
    		
    		var rp = new RunProperties();
    		var col = new Color {Rgb = "FFFF0000"};
    		rp.Append(col);
    		run.RunProperties = rp;
    		run.Append(txt);
    		si.Append(run);
    
    		run = new Run();
    		txt = new Text
    		{
    			Text = newText.Substring(pos1 + txtLen),
    			Space = SpaceProcessingModeValues.Preserve
    		};
    		run.Append(txt);
    		si.Append(run);
    	}
    }
    xlsx.Close();
