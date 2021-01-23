    ((CustomLabel)tlp.GetControlFromPosition(col, row).Controls[0]).BorderThickness = 6;
	((CustomLabel)tlp.GetControlFromPosition(col, row).Controls[0]).BorderColor = Color.Yellow;
    tlp.GetControlFromPosition(col, row).Controls[0].Text = tlp.GetControlFromPosition(col, row).Controls[0].Text;  // Transfer space information
	
	tlp.GetControlFromPosition(col, row).Refresh();     // Refresh Panel to show changes
