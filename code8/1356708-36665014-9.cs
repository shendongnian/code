    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    
        string val1 = dpl1.SelectedValue;
        string val2 = dpl2.SelectedValue;
        string val3 = dpl3.SelectedValue;
    
        dpl1.Items.Clear();
        dpl2.Items.Clear();
        dpl3.Items.Clear();
    
        // Fill the lists here
    
        SafeSelectValue(dpl1, val1);
        SafeSelectValue(dpl2, val2);
        SafeSelectValue(dpl3, val3);
    }
    private void SafeSelectValue(ListControl lst, string value)
    {
        // Makes sure that the value exists before selecting it
        if (lst.Items.FindByValue(value) != null)
        {
            lst.SelectedValue = value;
        }
    }
