    /** Display Contact in the contact pane**/
        private void lstItemContact_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ListViewItem item = (ListViewItem)sender;
            User selectedUser = (User) item.Content;
                        
            contactPane.Fullname = selectedUser.Name;
            contactPane.Email = selectedUser.Mail;
        }
        private void lstItemContact_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (e.Source != null)
                {
                    User selectedItem = (User) lstContacts.SelectedItem;
                    DragDrop.DoDragDrop(lstContacts, selectedItem, DragDropEffects.Move);
                }
            }
        }
        private void tbFavouritesDrop_Drop(object sender, DragEventArgs e)
        {
            User selectedUser = e.Data.GetData("AddressBook1.User") as User;
            MessageBox.Show(selectedUser.Name);
            
        }
