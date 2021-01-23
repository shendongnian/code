       private void ConnectListView( ListView lv , SelectionChangedEventHandler SelectionChanged, HoldingEventHandler Item_holding)
        {
            lv.SelectionChanged += SelectionChanged;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                ListViewItem item = (ListViewItem)lv.ContainerFromIndex(i);
                if (item != null)item.Holding += Item_holding;
            }
        }
