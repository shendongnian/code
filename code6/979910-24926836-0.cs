        void Items_CurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            var newItem = AssociatedObject.SelectedItem;
            var item = ((ICollectionView)sender).CurrentItem;
            var view = item as FrameworkElement;
            if (view == null)
            {
                return;
            }
            IAllowNavigation allowNavigation = view.DataContext as IAllowNavigation;
            if ((allowNavigation != null) &&
                (allowNavigation.CanNavigateFromMe() == false))
            {
                e.Cancel = true;
                AssociatedObject.SelectedItem = view;
               
            }
            else
            {
                AssociatedObject.SelectedItem = newItem;
            }
            ((ICollectionView)sender).Refresh();
            
        }
