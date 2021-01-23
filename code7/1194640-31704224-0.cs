    StringBuilder b = new StringBuilder();
    
    foreach (DataRow row in excelSheet.Rows)
    {
    	if (TToken.Checked)
    		b.AppendLine(string.Format("@T\t\t{0}", tempOutput));
    		
    	if (CDocdateToken.Checked)
    		b.AppendLine(string.Format("@C Docdate\t\t{0}", row[selectCDocdate].ToString()));
    	
    	if (CSubjectToken.Checked)
    		b.AppendLine(string.Format("@C Subject\t\t{0}", row[selectedCSubject].ToString()));	
    	
    	if (DToken.Checked)
    		b.AppendLine(string.Format("@D \t\t{0}", DTextBox.Text));	
    	
    	if (TiffFiles.Checked)
    		b.Append(TTextBox.Text + "{" + pageFromStr2 + "-" + pageToStr2 + "}.tif");
    	
    	b.AppendLine();
    }
    
    // generate everything in a single string.
    output = b.ToString();
