    private readonly Dictionary<string, Tuple<string, bool, bool>> _dropDownMap = new Dictionary<string, Tuple<string, bool, bool>>
    {
        {"GetAssetsBasicById", new Tuple<string, bool, bool>("(Please enter asset ids for e.g. 1,2)", false, true) },
        {"GetAssetDetailsByIds", new Tuple<string, bool, bool>("(Please enter asset ids for e.g. 1,2)", false, true) },
        ...
    };
    private void SetControlVisibility()
    {
        var mapping = _dropDownMap[DropDownList1.SelectedItem.Text];
        if (mapping != null)
        {
            Label2.Text = mapping.Item1;
            chkExcludeMAPFunds.Visible = mapping.Item2;
            chkPublishXML.Visible = mapping.Item3;
        }
    }
