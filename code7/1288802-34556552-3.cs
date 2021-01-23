    private void copyChecksButton_Click(object sender, EventArgs e)
    {
        if (clb2 != null)
            for (int i = 0; i < clb1.Items.Count; i++)
                    clb2.SetItemChecked(i, clb2.GetItemChecked(i));
    }
