     private void Grid_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Song selectedItem = (sender as Grid).DataContext as Song;
            //the above line will get the exact GridViewItem where the User Clicked
            this.ItemGridView.SelectedItem = selectedItem;
            //the above line will add the item into SelectedItem and hence, I can take any action after this which I require
            }
        }
