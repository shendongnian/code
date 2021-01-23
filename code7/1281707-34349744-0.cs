    int i = dtgShift.CurrentRow.Index;
    shiftID = dtgShift[0, i].Value;
    txtShiftName.Text = dtgShift[1, i].Value.ToString();
    dblInputShiftHrs.Text = dtgShift[2, i].Value.ToString();
    ListViewItem lvitem = default(ListViewItem);
    
    if (!string.IsNullOrWhiteSpace(dtgShift[3, i].Value.ToString()))
    {
         chkMon.Checked = true;
         lvitem = lvSched.Items.Add("Monday");
         lvitem.SubItems.Add(dtgShift[3, i].Value.ToString());
         lvitem.SubItems.Add(dtgShift[4, i].Value.ToString());
    }
