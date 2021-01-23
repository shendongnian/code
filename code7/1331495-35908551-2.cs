        private void DgAlarms_Sorting(object sender, DataGridSortingEventArgs e)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Collection);
            collectionView.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, e.Column.SortDirection.GetValueOrDefault()));
        }
