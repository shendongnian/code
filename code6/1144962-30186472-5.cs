    private class DropDownMappings
    {
        public DropDownMappings(label, excludeMAPFundsVisible, publishXMLVisible)
        {
            Label2Text = label;
            ExcludeMAPFundsVisible = excludeMAPFundsVisible;
            PublishXMLVisible = publishXMLVisible;
        }
        public string Label2Text { get; set; }
        public bool ExcludeMAPFundsVisible { get; set; }
        public bool PublishXMLVisible { get; set; }
    }
    private readonly Dictionary<string, DropDownMappings> _dropDownMap = new Dictionary<string, DropDownMappings>
    {
        {"GetAssetsBasicById", new DropDownMappings("(Please enter asset ids for e.g. 1,2)", false, true) },
        {"GetAssetDetailsByIds", new DropDownMappings("(Please enter asset ids for e.g. 1,2)", false, true) },
        ...
    };
    private void SetControlVisibility()
    {
        var mapping = _dropDownMap[DropDownList1.SelectedItem.Text];
        if (mapping != null)
        {
            Label2.Text = mapping.Label2Text;
            chkExcludeMAPFunds.Visible = mapping.ExcludeMAPFundsVisible;
            chkPublishXML.Visible = mapping.PublishXMLVisible;
        }
    }
