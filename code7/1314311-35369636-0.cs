    private void checkedListBoxReports_ItemCheck(object sender, ItemCheckEventArgs iceargs)
    {
        for (int i = 0; i < checkedListBoxReports.Items.Count; ++i)
        {
            if (i != iceargs.Index) 
                checkedListBoxReports.SetItemChecked(i, false);
        }
        string selectedRpt = checkedListBoxReports.Text;
        DisableParameterGroupBoxes();
        EnableParameterGroupBox(selectedRpt);
    }
