    private void SetControlVisibility()
	{
		string itemText = DropDownList1.SelectedItem.Text;
		bool b = false;
		if (itemText.Equals("GetAssetsBasicById", StringComparison.Ordinal) ||
			itemText.Equals("GetAssetDetailsByIds", StringComparison.Ordinal))
		{
			b = true;
			Label2.Text = "(Please enter asset ids for e.g. 1,2)";
		}
		else if (itemText.Equals("GetAssetsBasicBySedols", StringComparison.Ordinal) ||
			itemText.Equals("GetAssetDetailsBySedols", StringComparison.Ordinal))
		{
			b = true;
			Label2.Text = "(Please enter sedols for e.g. B1YW440,0003496)";
		}
		else if (itemText.Equals("GetInvestmentReportByIds", StringComparison.Ordinal))
			Label2.Text = "(Please enter asset ids for e.g. 1:100)";
		else if (itemText.Equals("GetInvestmentReportBySedol", StringComparison.Ordinal))
			Label2.Text = "(Please enter sedols for e.g. B1YW440:100)";
		else
			return;
		chkExcludeMAPFunds.Visible = !b;
		chkPublishXML.Visible = b;
	}
