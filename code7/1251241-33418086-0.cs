    // Fields
    private static string _siteUrl;
    private static string _userName;
    private static string _passWord;
    private static string _domain;
    private static DataTable dataTable;
    private ClientContext _clientContext;
    private Web _spWebsite;
    // We'll store the data in a table for ease
    dataTable = new DataTable();
    dataTable.Columns.Add("Name", typeof(string));
    dataTable.Columns.Add("Path", typeof(string));
    dataTable.Columns.Add("Proposal Grouping", typeof(string));
    dataTable.Columns.Add("Modified", typeof(DateTime));
    _clientContext = new ClientContext(_siteUrl);
    _clientContext.Credentials = new NetworkCredential(_userName, _passWord, _domain);
    _spWebsite = _clientContext.Web;
    List list = _spWebsite.Lists.GetByTitle(@"Managed Collateral");
    CamlQuery camlQuery = new CamlQuery();
    camlQuery.ViewXml = @"<View><Query></Query></View>";
    camlQuery.FolderServerRelativeUrl = @"/sites/collateral/Managed Collateral/Proposal Collateral";
    ListItemCollection listItems = list.GetItems(camlQuery);
    _clientContext.Load(listItems, items => items.Include(
        item => item.File.Name,
        item => item.File.ServerRelativeUrl,
        item => item["Proposal_x0020_Navigation_x0020_Grouping"],
        item => item["Modified"]));
    _clientContext.ExecuteQuery();
    if (listItems != null)
    {
        foreach (ListItem item in listItems)
        {
            DataRow dr = dataTable.NewRow();
            dr["Name"] = item.File.Name;
            dr["Path"] = item.File.ServerRelativeUrl;
            dr["Proposal Grouping"] = item["Proposal_x0020_Navigation_x0020_Grouping"];
            dr["Modified"] = item["Modified"];
            dataTable.Rows.Add(dr);
        }
    }
    dataGridView.DataSource = dataTable;
