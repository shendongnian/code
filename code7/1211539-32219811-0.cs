            if (e.RemovedItems.Count > 0 && e.AddedItems.Count > 0 && canChange)
            {
                e.Handled = true;
                canChange = false; // avoid infinite recursion
                ((ComboBox)sender).SelectedItem = e.RemovedItems[0];
                canChange = true; // reset to original value
                return;
            }
