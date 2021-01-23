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
    		TextBox tbac = new TextBox();
    		tbac.ID = tbACIDID;
    		tbac.Text = AccountCodeID;
    		tbac.Width = 50;
    		tbac.CssClass = "textbox";
    		cell = new TableCell();
    		cell.Controls.Add(tbac);
    		cell.Attributes.Add("class", "cell");
    		row.Cells.Add(cell);
    
    		//add Amount
    		tbam = new TextBox();
    		tbam.ID = tbAID;
    		tbam.Text = Amount;
    		tbam.Width = 100;
    		tbam.CssClass = "textbox";
    		cell.Controls.Add(tbam);
    		cell.Attributes.Add("class", "cell");
    		row.Cells.Add(cell);
    
    		//add save button
    		Button btn = new Button();
    		btn.Text = "Sacuvaj";
    		btn.CssClass = "saveButton";
    		btn.CommandArgument = 
    			"u" + separator + 
    			rowNo + separator + 
    			tbac.Text + separator + 
    			tbam.Text;
    		btn.Click += new EventHandler(Update);
    		cell.Controls.Add(btn);
    
    		//style cell
    		cell.Attributes.Add("class", "tableCell");
    		row.Cells.Add(cell);
    
    		//style row
    		row.Attributes.Add("class", "row");
    
    		return row;
    	}
