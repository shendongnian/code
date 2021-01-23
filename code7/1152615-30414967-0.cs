    protected List<string> clickOrderList = new List<string>();
    private void Form1_Load(object sender, EventArgs e)
    {
        // Populate the checked ListBox
        this.checkedListBox1.Items.Add("Row1");
        this.checkedListBox1.Items.Add("Row2");
        this.checkedListBox1.Items.Add("Row3");
        this.checkedListBox1.Items.Add("Row4");
    }
    private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (sender != null && e != null)
        {
            // Get the checkListBox selected time and it's CheckState
            CheckedListBox checkListBox = (CheckedListBox)sender;
            string selectedItem = checkListBox.SelectedItem.ToString();
            // If curent value was checked, then remove from list
            if (e.CurrentValue == CheckState.Checked &&
                clickOrderList.Contains(selectedItem))
            {
                clickOrderList.Remove(selectedItem);
            }
            // else if new value is checked, then add to list
            else if (e.NewValue == CheckState.Checked &&
                !clickOrderList.Contains(selectedItem))
            {
                clickOrderList.Insert(0, selectedItem);
            }
        }
    }
    private void ShowClickOrderButton_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string s in clickOrderList)
        {
            sb.AppendLine(s);
        }
        MessageBox.Show(sb.ToString());
    }
