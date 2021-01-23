        private void mylonglist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                LongListSelector ls = sender as LongListSelector;
                sample_data selected_item = ls.SelectedItem as sample_data;
                // unselected the previous selections
                foreach (sample_data sd in ls.ItemsSource)
                {
                    if (sd != selected_item)
                    {
                        sd.IsSelected = false;
                    }
                }
                // set the selected item (this will cause the background color to change)
                selected_item.IsSelected = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
