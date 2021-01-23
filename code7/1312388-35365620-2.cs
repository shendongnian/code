    public TableRow TRow(string AccountCodeID, string Amount, int rowNo)
    	{
    		TableCell cell = new TableCell();
    		TableRow row = new TableRow();
    		Label label = new Label();
    		string tbACIDID = "tbAccountCodeID" + rowNo;
    		string tbAID = "tbAmount" + rowNo;
    
    		//add row number
    		label.Text = (rowNo + 1) + ".";
    		cell.Controls.Add(label);
    		row.Cells.Add(cell);
    
    		//add AccountCodeID
    		TextBox tb = new TextBox();
    		tb.ID = tbACIDID;
    		tb.Text = AccountCodeID;
    		tb.Width = 50;
    		tb.CssClass = "textbox";
    		cell = new TableCell();
    		cell.Controls.Add(tb);
    		cell.Attributes.Add("class", "cell");
    		row.Cells.Add(cell);
    
    		//add Amount
    		tb = new TextBox();
    		tb.ID = tbAID;
    		tb.Text = Amount;
    		tb.Width = 100;
    		tb.CssClass = "textbox";
    		cell.Controls.Add(tb);
    		cell.Attributes.Add("class", "cell");
    		row.Cells.Add(cell);
    
    		//add save button
    		Button btn = new Button();
    		btn.Text = "Sacuvaj";
    		btn.CssClass = "saveButton";
    		btn.CommandArgument = 
    			"u" + separator + 
    			rowNo + separator + 
    			tbACIDID + separator + 
    			tbAID;
    		btn.Click += new EventHandler(Update);
    		cell.Controls.Add(btn);
    
    		//style cell
    		cell.Attributes.Add("class", "tableCell");
    		row.Cells.Add(cell);
    
    		//style row
    		row.Attributes.Add("class", "row");
    
    		return row;
    	}
