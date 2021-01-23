    var tabPage2 = ShiftsViewTab.TabPages.Cast<TabPage>
                                .SingleOrDefault(x => x.Name == "tabPage2");
    if (tabPage2 == null)
        return;
    foreach (var clb in tabPage2.Controls.OfType<CheckedListBox>())
    {
        clb.Items.Clear();
        clb.Items.AddRange(Settings.Default.ShiftList.Cast<object>().ToArray());
    }
