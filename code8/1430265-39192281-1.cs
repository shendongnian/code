    ItemsCategoriesTracked.LoadCompleted += new EventHandler<LoadCompletedEventArgs>((sender, e) => DataServiceCollection_LoadCompleted<ItemsCategories>(sender, e, ItemsCategories_CVSrc));
    private void DataServiceCollection_LoadCompleted<T>(object sender, LoadCompletedEventArgs e, CollectionViewSource target)
        {
            if (e.Error == null)
            {
                if ((sender as DataServiceCollection<T>).Continuation != null)
                {
                    (sender as DataServiceCollection<T>).LoadNextPartialSetAsync();
                }
                else
                {
                    target.Source = (sender as DataServiceCollection<T>);
                }
            }
            else
            {
                MessageBox.Show(string.Format("{0}: An error has occured: {1}", typeof(T).Name, e.Error.Message));
            }
        }
