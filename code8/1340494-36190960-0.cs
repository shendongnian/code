        private void TreeViewName_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = e.OriginalSource as CheckBox;
            MyClass dataContext = checkBox?.DataContext as MyClass;
            if (dataContext != null)
            {
                // Do something with MyClass instance
            }
        }
