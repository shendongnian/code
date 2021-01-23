    public void Page_Load(Object sender, EventArgs e)
    {
       // Get items from database table 1
        var items1 = GetTable1Data();
        foreach(var item in items1)
        {
           this.checkboxList1.Items.Add( new ListItem(item.DisplayMember, item.ValueMember));
        }
        // Get items from database table 2
        var items2 = GetTable2Data();
        foreach(var item in items2)
        {
           this.checkboxList1.Items.Add( new ListItem(item.DisplayMember, item.ValueMember));
        }
    }
