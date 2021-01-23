        public DateTime? DateTimeValue
        {
            get { return (DateTime?)GetValue(DateTimeValueProperty); }
            set { SetValue(DateTimeValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DateTimeValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateTimeValueProperty =
            DependencyProperty.Register("DateTimeValue", typeof(DateTime?), typeof(MainWindow), new PropertyMetadata(null, new PropertyChangedCallback(DateTimeValueProperty_Changed)));
        private static void DateTimeValueProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mw = d as MainWindow;
            System.Diagnostics.Debug.WriteLine("d is " + d == null ? "null" : d.GetType().FullName);
            if (mw != null && e.Property == DateTimeValueProperty)
            {
                var value = e.NewValue as DateTime?;
                var listbox = FindChild<ListBox>(mw, "listbox");
                if (value == null)
                    listbox.Items.Add("[NULL]");
                else
                    listbox.Items.Add(value.Value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }
        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
