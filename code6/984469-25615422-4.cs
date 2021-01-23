        private void objectListViewUserList_Click(object sender, EventArgs e)
        {
            if (objectListViewUserList.MouseMoveHitTest.Item != null)
                selectedItemText = objectListViewUserList.MouseMoveHitTest.Item.Text;
            else
                selectedItemText = "";
        }
