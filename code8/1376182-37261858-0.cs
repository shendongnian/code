    class Item
    {
        public   int id;
        public string description;
        public int typeid;
    }
    void FillDropDown()
    {
        List<Item> Items = new List<Item>();
        // Fill Items
        DropDownList.Items.Clear();
        Items.ForEach(I => 
        {
            DropDownList.Items.Add(new ListItem(I.description, I.id + ";" + I.typeid));
        });
    }
