    protected void chkbxFileTypes_SelectedIndexChanged(object sender, EventArgs e)
            {
               List<ListItem> selected = chkbxFileTypes.Items.Cast<ListItem>()
              .Where(li => ! li.Selected)
              .ToList();
            }
