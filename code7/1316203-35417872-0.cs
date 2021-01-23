    DXPopupMenu menu = new DXPopupMenu();
    menu.Items.Add(new DXMenuItem("Admin"));
    menu.Items.Add(new DXMenuItem("Guest"));
    // ... add more items
    dropDownButton1.DropDownControl = menu;
    // subscribe item.Click event
    foreach(DXMenuItem item in menu.Items) 
        item.Click += item_Click;
    // setup initial selection
    dropDownButton1.Text = menu.Items[0].Caption;
    //...
    void item_Click(object sender, EventArgs e) {
        // synchronize selection
        dropDownButton1.Text = ((DXMenuItem)sender).Caption;
        // ... do something specific
    }
