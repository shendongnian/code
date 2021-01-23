private void uxListViewTest_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
    if (e.IsSelected) {
        e.Item.BackColor = SystemColors.Highlight;
        e.Item.ForeColor = SystemColors.HighlightText;
    }
    else {
        e.Item.BackColor = BackColor;
        e.Item.ForeColor = ForeColor;
    }
}
