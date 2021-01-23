    //.... View/Window Class
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
          MyListBox.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }
        private void ItemContainerGenerator_ItemsChanged(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
          if ((e.Action == NotifyCollectionChangedAction.Add) && DetectingNewItems)
          {
            var listboxitem = LB.ItemContainerGenerator.ContainerFromIndex(e.Position.Index + 1) as ListBoxItem;
            var editControl = FindFirstDescendantChildOf<EditableTextBlock>(listboxitem);
            if (editcontrol != null) editcontrol.IsInEditMode = true;
          }
        }
        public static T FindFirstDescendantChildOf<T>(DependencyObject dpObj) where T : DependencyObject
        {
            if (dpObj == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(dpObj); i++)
            {
                var child = VisualTreeHelper.GetChild(dpObj, i);
                if (child is T) return (T)child;
                var obj = FindFirstChildOf<T>(child);
                if (obj != null) return obj;
            }
            return null;
        }
