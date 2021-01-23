        private void Add_Picture(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                object displayedItem = clickedButton.DataContext;
                int index = this.myItems.Items.IndexOf(displayedItem);
                int x = index % 4;
                int y = index / 4;
                MessageBox.Show("x: " + x + " | y: " + y);
            }
        }
