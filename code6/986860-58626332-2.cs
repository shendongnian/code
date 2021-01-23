    private void DataGridSelectionChanged(IList test)
    {
        foreach (var item in test)
        {
            MessageBox.Show(((Friend)item).ID.ToString());
        }
    }
