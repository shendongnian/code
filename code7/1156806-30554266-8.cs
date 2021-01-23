    private static void OnTextBoxSet(DependencyObject dObj, DependencyPropertyChangedEventArgs e)
        {
            var listView = dObj as ListView;
            var text = e.NewValue as string;
            if ((listView == null) || (text == null)) return;
            var view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            if (view == null) return;
            view.Filter += item =>
            {
                var type = item.GetType();
                if (type == typeof(Employee))
                {
                    var itemPl = (Employee)item;
                    return itemPl.UserName.Contains(text);
                }
                if (type == typeof(Person))
                {
                    var itemPl = (Person)item;
                    return itemPl.Name.Contains(text);
                }
                //and more types .............. 
                return false;
            };
        }
