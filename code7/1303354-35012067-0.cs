            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                ICollectionView view = (ICollectionView)CollectionViewSource.GetDefaultView(vm.Students);
                view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                view.CollectionChanged += view_CollectionChanged;
                view.Refresh();
            }
    
            void view_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("view_CollectionChanged changed !");
            }
