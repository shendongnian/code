    private void lb_ProfileList_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        foreach (string item in theListItems)
        {
            for (int d = 0; d < lb_AllProjects.SelectedItems.Count; d++)
            {
                lb_SelectedProjects.Items.Add(item);
                lb_AllProjects.Items.Remove(item);
            }
        }
    }
