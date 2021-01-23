    private void remove_Click(object sender, EventArgs e)
    {
        for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
        {
            int idx = listBox1.SelectedIndices[x];
            //listBox1.Items.RemoveAt(idx);
            listOfCountries.RemoveAt(idx)l
        }
        listBox1.RefreshItems();
    }
