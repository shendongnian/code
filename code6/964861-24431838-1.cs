    add Simple  button click(Button_Click) to all the button (e.g button1 , button2)... In below code assume that u had button name property  as button1 and button2.
    
     
    
        private void Button_Click(object sender, RoutedEventArgs e)
                {
                    Button b = sender as Button;
                    List<StackPanel> CollapsedStackPanel = new List<StackPanel>();
                    if (b.Name == Button1.Name)
                    {
                        dgrid.ItemsSource = FillDataGrid("ShipWorksConnection", "GetPicklistItems", "PickList");
                        CollapsedStackPanel.Add(SP2);    //add only stackpanel that u want set Collapsed
                        CollapsedStackPanel.Add(SP3);    //add only stackpanel that u want set Collapsed
                        CollapsedStackPanel.Add(SP);    //add only stackpanel that u want set Collapsed
                    }
                    else if (b.Name == Button2.Name)
                    {
                        dgrid.ItemsSource = FillDataGrid("ShipWorksConnection", "GetPicklistItems", "PickList");
                        CollapsedStackPanel.Add(SP1);    
                        CollapsedStackPanel.Add(SP3);    //add only stackpanel that u want set Collapsed
                        CollapsedStackPanel.Add(SP4);    //add only stackpanel that u want set Collapsed
                    }
        //can add here more else if other buttons as well
                    SetStackPanelVisibility(CollapsedStackPanel);
                }
        
                private void SetStackPanelVisibility(List<StackPanel> CollapsedStackPanel)
                {
                    //get all the stackpanel in current window 
                    //if its in visible list then set its visiblity to visible
                    // else set its visibility to collapsed
                    foreach (StackPanel item in FindVisualChildren<StackPanel>(this))
                    {
                        if (CollapsedStackPanel.Contains(item))
                        {
                            item.Visibility = System.Windows.Visibility.Collpsed;
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
