    UnitData_DataGridView.ScrollBars = ScrollBars.Both;
    frm.Size = new Size(0,0);// Screen.PrimaryScreen.WorkingArea.Size;
    frm.Show();
    foreach (DataGridViewRow row in UnitData_DataGridView.Rows)
    {
      ...
      ...
      ...
    }
    frm.Location = new Point(0, 0);
    frm.Size =  Screen.PrimaryScreen.WorkingArea.Size;
    frm.AutoScroll = true;
