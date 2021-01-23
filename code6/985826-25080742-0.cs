    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        if (TabConAddInfo.ActiveTab.TabIndex == 0)
        {
            addSplash();
        }
        else if (TabConAddInfo.ActiveTab.TabIndex == 1)
        {
            addMainCat();
        }
    }
