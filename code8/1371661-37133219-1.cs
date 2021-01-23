        private void qqq_Click(object sender, RoutedEventArgs e)
        {
            var e1=listBox.Items;
            foreach (var c in listBox.ItemsSource)
            {
                MessageBox.Show(((FooClass)c).IsChecked.ToString());
            }
            
        }
