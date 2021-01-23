        public void fillOnlineUsers()
        {
            objectListViewUserList.ClearObjects();
            objectListViewUserList.AddObjects(onlineUsers);
            objectListViewUserList.BuildList();
            if (selectedItemText != "")
            {
                foreach (OLVListItem olvi in objectListViewUserList.Items)
                    if (olvi.Text == selectedItemText)
                        olvi.Selected = true;
            }
        }
