            async void FriendListView_ItemTapped(object sender, ItemTappedEventArgs e)
            {           
                var el = e.Item as ProfileItem;
                SelectedItem = el;
                if (e.Item != null)
                {
                   await Navigation.PushAsync(new FriendProfile(el));
                }
                ((ListView)sender).SelectedItem = null; // de-select the row
            }
