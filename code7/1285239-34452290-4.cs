     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                TextBox foundTextBox = FindChild<TextBox>(this, "txt");
    
                foundTextBox.Text = "fdf";
            }
    
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
    
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                WrapPanel wpOrderList = new WrapPanel();
                TextBox txtCount = new TextBox();
                txtCount.Text = "1";
                txtCount.Height = 20;
                txtCount.Width = 20;
                txtCount.Name = "txt";
                wpOrderList.Children.Add(txtCount);
                stk.Children.Add(wpOrderList);
            }    
        }   
