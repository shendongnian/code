    private ListViewItem currentSelection = null;
    private bool pending_changes = false;
    private bool cancel_flag = false;
    private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        Console.WriteLine("Item " + e.ItemIndex + " is now " + e.IsSelected);
        if (e.Item != currentSelection)
        {
            // if another item gets selected but there are pending changes
            if (e.IsSelected && pending_changes)
            {
                if (cancel_flag)
                {
                    // this handles the second mysterious event
                    cancel_flag = false;
                    currentSelection.Selected = true;
                    e.Item.Selected = false;
                    return;
                }
                Console.WriteLine("uh oh. pending changes.");
                var res = MessageBox.Show("Do you want to save changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                switch (res)
                {
                    case DialogResult.Cancel:
                        // we dont want to change the selected item, so keep it selected
                        currentSelection.Selected = true;
                        e.Item.Selected = false;
                        // for some reason, we will get the same event with the same argments again, 
                        // after we click the cancel button, so remember our decision
                        cancel_flag = true;
                        break;
                    case DialogResult.Yes:
                        // saving here. if possible without clicking the button, but by calling the method that is called to save
                        pending_changes = false;
                        currentSelection = e.Item;
                        break;
                    case DialogResult.No:
                        pending_changes = false;
                        currentSelection = e.Item;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (e.IsSelected && !pending_changes)
            {
                currentSelection = e.Item;
            }
        }
    }
