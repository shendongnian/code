         private void LbContacts_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            args.ItemContainer.Holding -= lbContactsItem_Holding;
            args.ItemContainer.Holding += lbContactsItem_Holding;
        }
