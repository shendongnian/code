        private IEnumerable<T> GetVisualChildren<T>(DependencyObject parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    foreach (var item in GetVisualChildren<T>(v))
                    {
                        yield return item;
                    }
                }
                if (child != null)
                {
                    yield return child;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetVisualChildren<ComboBox>(dataGrid).ToList().ForEach(c => c.SelectedItem  = null);
        }
