        void lv_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            YourItem item = args.Item as YourItem;
            if (item != null)
            {
                if (item == TheItemYouWant)
                {
                    ListView lv = sender as ListView;
                    lv.ScrollIntoView(args.Item);
                }
            }
        }
