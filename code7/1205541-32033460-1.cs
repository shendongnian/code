        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RadioButton obj = new RadioButton();
            obj.Content = "Group " + ++numberOfGroups;
            ListBox1.Items.Add(obj);
            ListBox1.SelectedItem = obj;
            obj.IsChecked = true;
            ListBox1.Focus();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                int position = ListBox1.Items.IndexOf(ListBox1.SelectedItem);
                ListBox1.Items.Remove(ListBox1.SelectedItem);
                if (ListBox1.Items.Count == 0) return;
                if (position == 0)
                {
                    ListBox1.SelectedItem = ListBox1.Items[0];
                }
                else
                {
                    ListBox1.SelectedItem = ListBox1.Items[position - 1];
                }
                (ListBox1.SelectedItem as RadioButton).IsChecked = true;
            }
        }
