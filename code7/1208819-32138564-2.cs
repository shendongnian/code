        public void SetSelectedItem(ListViewItem item)
        {
            var index = -1;
            if (item != null)
            {
                index = IndexFromContainer(item);
            }
            for (var i = 0; i < Items.Count; i++)
            {
                var lvi = (ListViewItem) ContainerFromIndex(i);
                if(lvi == null) continue;
                if (i != index)
                {
                    lvi.IsSelected = false;
                }
                else if (i == index)
                {
                    lvi.IsSelected = true;
                }
            }
        }
