    foreach (var item in Assembly.GetExecutingAssembly().GetTypes()
                                 .Where(x => x.BaseType == typeof(Item)))
    {
        comboBox1.Items.Add(item);
    }
    comboBox1.DisplayMember = "Name";
