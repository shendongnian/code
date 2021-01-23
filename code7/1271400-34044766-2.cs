    for (int i = 0; i < lbl; i++)
    {
    	HyperLink lnkBtn = new LinkButton();
    	lnkBtn.CssClass = "btn";
    	lnkBtn.Text = textList[i];
    	lnkBtn.NavigateUrl = linkList[i];
        lnkBtn.Target = "myFrame";
    	LiteralControl linebreak = new LiteralControl("<br />");
    	table1.Rows[0].Cells[0].Controls.Add(lnkBtn);
    	table1.Rows[0].Cells[0].Controls.Add(linebreak);
    }
