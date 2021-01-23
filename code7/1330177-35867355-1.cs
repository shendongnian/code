    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        if (_hideTwoOutOfThreeTabs)
        {
            foreach (var tabPage in tabControl1.TabPages.Cast<TabPage>())
            {
                // TODO: Some logical test to ensure this is the desired tab control to hide
                // if (tabPage)
                {
                    tabPage.Visible = false;
                }
            }
        }
    }
