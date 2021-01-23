    tabControl1.SelectedIndexChanged += delegate
    {
        ActiveControl = tabControl1.SelectedTab.Controls.Cast<Control>()
                                   .SingleOrDefault(x => x.TabIndex == 0);
    };
