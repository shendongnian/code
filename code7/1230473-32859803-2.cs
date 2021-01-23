    private List<Record> list = new List<Record>();
    protected void Page_Load(object sender, EventArgs e)
    {
        var column1 = ASPxTreeList1.DataColumns["CategoryName"];
        var column2 = ASPxTreeList1.DataColumns["Description"];
        var nodes = ASPxTreeList1.GetVisibleNodes();
        foreach (var node in nodes)
        {
            var txtBox1 = (ASPxTextBox)ASPxTreeList1.FindDataCellTemplateControl(node.Key, column1, "txtBox");
            var txtBox2 = (ASPxTextBox)ASPxTreeList1.FindDataCellTemplateControl(node.Key, column2, "txtBox");
            if (txtBox1 == null || txtBox2 == null)
                continue;
            int id = Convert.ToInt32(node.Key);
            list.Add(new Record(id, txtBox1.Text, txtBox2.Text));
        }
    }
    protected void ASPxTreeList1_CustomCallback(object sender, TreeListCustomCallbackEventArgs e)
    {
        if (e.Argument == "post")
        {
            for (int i = 0; i < list.Count; i++)
            {
                AccessDataSource1.UpdateParameters["CategoryName"].DefaultValue = list[i].CategoryName;
                AccessDataSource1.UpdateParameters["Description"].DefaultValue = list[i].Description;
                AccessDataSource1.UpdateParameters["CategoryID"].DefaultValue = list[i].Id.ToString();
                //                AccessDataSource1.Update();  << Uncomment this line to update data!
            }
            ASPxTreeList1.DataBind();
        }
    }
