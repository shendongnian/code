    private void OpenOverviewForm()
    {
        Overview formOverview = new Overview();
    
        for (int i = 0; i < callListNL.Count; i++)
        {
            ListViewItem item = new ListViewItem(callListNL[i].Opco);
            item.SubItems.Add(callListNL[i].UserID);
            item.SubItems.Add(callListNL[i].Email);
            item.SubItems.Add(callListNL[i].Title);
            formOverview.listView1Overview.Items.Add(item);
        }
    
        for (int i = 0; i < callListPL.Count; i++)
        {
            ListViewItem item = new ListViewItem(callListPL[i].Opco);
            item.SubItems.Add(callListPL[i].UserID);
            item.SubItems.Add(callListPL[i].Email);
            item.SubItems.Add(callListPL[i].Title);
            formOverview.listView1Overview.Items.Add(item);
        }
        formOverview.StartPosition = FormStartPosition.CenterScreen;
        formOverview.ShowDialog();
        if (formOverview.SelectedItem != null)//just in case the user closes formOverview without double-clicking any item
        {
            OverviewFormDisplay(formOverview.SelectedItem);
        }
    }
