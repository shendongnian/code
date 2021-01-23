    private void SetControlVisibility()
    {
        if (DropDownList1.SelectedItem != null)
        {
            switch (DropDownList1.SelectedItem.Text)
            {
                case "GetAssetsBasicById":
                case "GetAssetDetailsByIds":
                    Label2.Text = "(Please enter asset ids for e.g. 1,2)";
                    chkExcludeMAPFunds.Visible = false;
                    chkPublishXML.Visible = true;
                    break;
    
                case "GetAssetsBasicBySedols":
                case "GetAssetDetailsBySedols":
                    Label2.Text = "(Please enter sedols for e.g. B1YW440,0003496)";
                    chkExcludeMAPFunds.Visible = false;
                    chkPublishXML.Visible = true;
                    break;
    
                case "GetInvestmentReportByIds":
                    Label2.Text = "(Please enter asset ids for e.g. 1:100)";
                    chkExcludeMAPFunds.Visible = true;
                    chkPublishXML.Visible = false;
                    break;
    
                case "GetInvestmentReportBySedol":
                    Label2.Text = "(Please enter sedols for e.g. B1YW440:100)";
                    chkExcludeMAPFunds.Visible = true;
                    chkPublishXML.Visible = false;
                    break;
    
                default:
                    // we do it wrong :(
                    throw new NotSupportedException();
            }
        }
    }
