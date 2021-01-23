    private void clbEmailsSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        BeginInvoke((Action)(() =>
        {
            btnEdit.Enabled = btnDelete.Enabled =
                (clbEmailsSubjects.CheckedItems.Count == 1);
        }));
    }
