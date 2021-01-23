    bool hasDeleteColumn=false;
    foreach (DataGridViewColumn  item in dataGridView1.Columns)
        {
           if (item.GetType() == typeof(DataGridViewLinkColumn) && item.HeaderText=="Delete")
              {
                  hasDeleteColumn = true;
                  break;
              }
        }
    if(!hasDeleteColumn)
      {
        // Adding columns if not existing
        DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
        Deletelink.UseColumnTextForLinkValue = true;
        Deletelink.HeaderText = "Delete";
        Deletelink.DataPropertyName = "lnkColumn";
        Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
        Deletelink.Text = "Delete";
        dataGridView1.Columns.Add(Deletelink);
        dataGridView1.Refresh();
      }
