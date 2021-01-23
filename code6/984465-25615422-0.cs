        private void objectListViewUserList_Click(object sender, EventArgs e)
        {
            if (objectListViewUserList.MouseMoveHitTest.Item.Text != null)
                selectedItemText = objectListViewUserList.MouseMoveHitTest.Item.Text;
        }
