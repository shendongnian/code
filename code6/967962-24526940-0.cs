    protected override void OnLoad(EventArgs e)
    {
        LoadStuff();
    }
    private void LoadStuff()
    {
            try
            {
                string controlName;
                int index = YOUR_MULTI_PAGE_CONTROL.SelectedIndex;
                if (index > 0)
                { controlName = YOUR_MULTI_PAGE_CONTROL.PageViews[index].ID.Trim().Remove(index); }
                else
                { controlName = YOUR_MULTI_PAGE_CONTROL.PageViews[index].ID; }
    
                Control pageViewContents = LoadControl(controlName + ".ascx");
                pageViewContents.ID = YOUR_MULTI_PAGE_CONTROL.PageViews[index].ID + "userControl";
                YOUR_MULTI_PAGE_CONTROL.PageView.Controls.Add(pageViewContents);
            }
            catch (Exception ex)
            {
                Utility.WalkException(this, ex, "There was an error while performing this operation.");
            }
    }
