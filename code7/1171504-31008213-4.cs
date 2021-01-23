    public partial class ProfileWindow : Window
    {
        UserControl control1, control2;
        // or if you want the exact types:
        // UserControl1 control1;
        // UserControl2 control2;
        
        public ProfileWindow()
        {
            control1 = new UserControl1();
            control2 = new UserControl2();
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                if (<your_condition>) //then you want to add UserControl1 instance
                {
                    if (!dgRoot.Children.Contains(control1))
                    {
                        dgRoot.Children.Clear();  
                        control1.SetValue(Grid.ColumnProperty, 2);
                        this.dgRoot.Children.Add(control1);                      
                    }
                }
                else //else you want to add UserControl2 instance
                {
                    if (!dgRoot.Children.Contains(control2))
                    {
                        dgRoot.Children.Clear();  
                        control2.SetValue(Grid.ColumnProperty, 2);
                        this.dgRoot.Children.Add(control2);                      
                    }
                }
        }
    }
