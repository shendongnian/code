    ClientContext context = new ClientContext(ServerText.Text);
    List list = context.Web.Lists.GetByTitle("Tasks");
    CamlQuery query = new CamlQuery();
    query.ViewXml = "<View/>";
    ListItemCollection items = list.GetItems(query);
    context.Load(list);
    context.Load(items);
    context.ExecuteQuery();
    DataTable table = new DataTable();
    table.Columns.Add("Id");
    table.Columns.Add("Title");
    foreach (ListItem item in items)
    table.Rows.Add(item.Id, item["Title"]);
