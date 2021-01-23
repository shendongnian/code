     private void OnSetFilterButtonClick(object sender, RoutedEventArgs e)
            { 
                //Create a new listview by the ItemsSource,Apply Filter to the new listview
                ListCollectionView listView = new ListCollectionView(View1.ItemsSource as IList); 
                listView.Filter = IsAllowedItem;
                View1.ItemsSource = listView;
                UpdateFilterLabels();
            }
