        private void Button_Click(object sender, RoutedEventArgs e)
        {   //pretend you want to access the second item
            object myItem = myListbox.Items[1];
            ListBoxItem container = myListbox.ItemContainerGenerator.ContainerFromItem(myItem) as ListBoxItem;
            ContentPresenter contentPresenter = FindVisualChild<ContentPresenter>(container);
            DataTemplate myDataTemplate = contentPresenter.ContentTemplate;
            TextBox myTextbox = myDataTemplate.FindName("myTextbox", contentPresenter)as TextBox;
            if (myTextbox != null)
            {
                myTextbox.Text = "text changed!";
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        public static childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            foreach (childItem child in FindVisualChildren<childItem>(obj))
            {
                return child;
            }
            return null;
        }
