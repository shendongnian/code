        private void check_Click(object sender, RoutedEventArgs e)
        {
            DataGridRow dgRow = (DataGridRow)(dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem));
            if (dgRow == null) return;
            DataGridDetailsPresenter dgdPresenter = FindVisualChild<DataGridDetailsPresenter>(dgRow);
            DataTemplate template = dgdPresenter.ContentTemplate;
            TextBox textBox = (TextBox)template.FindName("toCheck", dgdPresenter);
            string needCheck = textBox.Text;
            if (needCheck == "abc")
            {
                MessageBox.Show("its abc");
            }
        }
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
