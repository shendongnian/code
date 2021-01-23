        private void ListM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListGrid media = (ListGrid)ListM.SelectedItems[0];
            string age = media.Title;
            MessageBox.Show("Selected : " + age);
        }
