    private void SetControlVisibility()
	{
		string itemText = DropDownList1.SelectedItem.Text;
		bool b = true;
		if (itemText.Equals("GetAssetsBasicById") ||
			itemText.Equals("GetAssetDetailsByIds"))
			Label2.Text = "(Please enter asset ids for e.g. 1,2)";
		else if (itemText.Equals("GetAssetsBasicBySedols") ||
			itemText.Equals("GetAssetDetailsBySedols"))
			Label2.Text = "(Please enter sedols for e.g. B1YW440,0003496)";
		else
		{
			b = false;
			if (itemText.Equals("GetInvestmentReportByIds"))
				Label2.Text = "(Please enter asset ids for e.g. 1:100)";
			else if (itemText.Equals("GetInvestmentReportBySedol"))
				Label2.Text = "(Please enter sedols for e.g. B1YW440:100)";
			else
				return;
		}
		chkExcludeMAPFunds.Visible = !b;
		chkPublishXML.Visible = b;
	}
