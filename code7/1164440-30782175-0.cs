        private void Thumbnails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int item = Thumbnails.SelectedIndex + 1; //get original index for each element in ListView
            object content = Thumbnails.SelectedItem;
            if (content is Image)
            {
                MessageBox.Show(Convert.ToString(item));
            }
        }
