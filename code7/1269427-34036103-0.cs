        private void radButton1_Click(object sender, EventArgs e)
        {
            IterateItems(radMenu1.Items);
        }
        void IterateItems(RadItemOwnerCollection items)
        {
            foreach (RadMenuItemBase item in items)
            {
                if (item.IsRootItem)
                {
                    item.MouseEnter += item_MouseEnter;
                }
                if (item.HasChildItemsToShow)
                {
                    IterateItems(item.Items);
                }
            }
        }
        void item_MouseEnter(object sender, EventArgs e)
        {
            RadMenuItem hoveredItem = (RadMenuItem)sender;
            hoveredItem.DropDown.Show();
        }
