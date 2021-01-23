    private class DropDownMappings
    {
        public string Label2Text { get; set; }
        public bool ExcludeMAPFundsVisible { get; set; }
        public bool PublishXMLVisible { get; set; }
    }
    private readonly Dictionary<string, DropDownMappings> _dropDownMap = new Dictionary<string, DropDownMappings>
    {
        {"GetAssetsBasicById", new DropDownMappings
            {
                Label2Text = "(Please enter asset ids for e.g. 1,2)",
                ExcludeMAPFundsVisible = false,
                PublishXMLVisible = true
            }
        },
        {"GetAssetDetailsByIds", new DropDownMappings
            {
                Label2Text = "(Please enter asset ids for e.g. 1,2)",
                ExcludeMAPFundsVisible = false,
                PublishXMLVisible = true
            }
        },
        ...
    };
    private void SetControlVisibility()
    {
        var mapping = _dropDownMap[DropDownList1.SelectedItem.Text];
        Label2.Text = mapping.Label2Text;
        chkExcludeMAPFunds.Visible = mapping.ExcludeMAPFundsVisible;
        chkPublishXML.Visible = mapping.PublishXMLVisible;
    }
