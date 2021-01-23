     private void deleteEntryBTN_Click(object sender, EventArgs e)
        {
            try
            {
                while (recipientBox.SelectedItems.Count > 0)
                {
                    recipientBox.Items.Remove(recipientBox.SelectedItems[0]);
                }
            }
            catch { }
            UpdateNoOfEmails();
        }
