    private ListViewItem currentSelection = null;
    private bool pending_changes = false;
    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        if (e.Item == currentSelection)
        {
            // if the current Item gets unselected but there are pending changes
            if (!e.IsSelected && pending_changes)
            {
                var res = MessageBox.Show("Do you want to save changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (res)
                {
                    case DialogResult.Cancel:
                        // we dont want to change the selected item, so keep it selected
                        e.Item.Selected = true;
                        break;
                    case DialogResult.Yes:
                        button_Save.PerformClick();
                        pending_changes = false;
                        break;
                    case DialogResult.No:
                        pending_changes = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        else // not the selected button
        {
            if (!pending_changes && e.IsSelected)
            {
                // Item may be selected and we save it as the new current selection
                currentSelection = e.Item;
            }
            else if (pending_changes && e.IsSelected)
            {
                // Item may not be enabled, because there are pending changes
                e.Item.Selected = false;
            }
        }
    }
