    private void Button_Click(object sender, RoutedEventArgs e)
            {
                Button b = sender as Button;
                List<StackPanel> VisibleStackPanel = new List<StackPanel>();
                if (b.Name == Button1.Name)
                {
                    dgrid.ItemsSource = FillDataGrid("ShipWorksConnection", "GetPicklistItems", "PickList");
                    VisibleStackPanel.Add(SP1);    //add only stackpanel that u want set visible
                }
                else if (b.Name == Button2.Name)
                {
                    dgrid.ItemsSource = FillDataGrid("ShipWorksConnection", "GetPicklistItems", "PickList");
                    VisibleStackPanel.Add(SP2);    
                }
    //can add here more else if other buttons as well
    SetStackPanelVisibility(VisibleStackPanel);
            }
    
            private void SetStackPanelVisibility(List<StackPanel> VisibleStackPanel)
            {
                //get all the stackpanel in current window 
                //if its in visible list then set its visiblity to visible
                // else set its visibility to collapsed
                foreach (StackPanel item in FindVisualChildren<StackPanel>(this))
                {
                    if (VisibleStackPanel.Contains(item))
                    {
                        item.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        item.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
            }
    
    
            public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
            {
                //preferably put this code in some common place so u can use whenever u want.
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
