    <asp:CheckBoxList runat="server" ID="CheckBoxList1" />
    <asp:Button runat="server" ID="Button1" Text="Submit" OnClick="Button1_Click" />
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CheckBoxList1.Items.Add(new ListItem("One", "1"));
            CheckBoxList1.Items.Add(new ListItem("Two", "2"));
            CheckBoxList1.Items.Add(new ListItem("Three", "3"));
            CheckBoxList1.Items.Add(new ListItem("Four", "4"));
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        int selectedCount = 0;
        var selectedText = new List<string>();
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                selectedCount++;
                selectedText.Add(item.Text);
            }
        }
    }
