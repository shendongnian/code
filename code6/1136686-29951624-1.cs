    // BTN 1
    private void Btn_1_Click(object sender, EventArgs e)
    {
        int value = 1 - 1;
        int iCount = ListBoxMain.Items.Count;
        if (iCount > value)
        {
            string item = ListBoxMain.Items[value].ToString();
            TreviewNodesSelection(item, value);
        }
    }
    // BTN 2
    private void Btn_2_Click(object sender, EventArgs e)
    {
        int value = 2 - 1;
        int iCount = ListBoxMain.Items.Count;
        if (iCount > value)
        {
            string item = ListBoxMain.Items[value].ToString();
            TreviewNodesSelection(item, value);
        }
    }
