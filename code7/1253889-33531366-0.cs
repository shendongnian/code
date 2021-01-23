        public RelayCommand<ListViewItem> DeleteCmd { get; private set; }
         /// <summary>
        /// View Model for Delete Window.
        /// </summary>
        public DeleteVM()
        {
           DeleteCmd = new RelayCommand<ListViewItem>(ShowDelete);
        }
        /// <summary>
        /// Method to Show Delete options.
        /// </summary>
        private void ShowDelete(ListViewItem lv)
        {
            Button btnX = FindChild<Button>(lv,"btnX");
            Button btnYes = FindChild<Button>(lv, "btnYes");
            Button btnNo = FindChild<Button>(lv, "btnNo");
            Label lblConfirm = FindChild<Label>(lv, "lblConfirm" );           
            System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal,
             (Action)delegate()
             {
                 btnX.Visibility = Visibility.Hidden;
                 btnYes.Visibility = Visibility.Visible;
                 btnNo.Visibility = Visibility.Visible;
                 lblConfirm.Visibility = Visibility.Visible;
                 //BtnXVisibility = Visibility.Hidden;
                 //BtnYesVisibility = System.Windows.Visibility.Visible;
                 //btnNoVisibility = System.Windows.Visibility.Visible;
                 //LblConfirmVisibility = System.Windows.Visibility.Visible;
                 Background = Brushes.White;
             });
        }
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = System.Windows.Media.VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(parent, i);
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
        
