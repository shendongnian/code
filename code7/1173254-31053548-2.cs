    <Setter Property="Tag" Value="{Binding Path=Date}" />
    private void myCal_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
            {
                var grid = FindVisualChildByName<Grid>(myCal, "MonthView");
                DateTime? dtBegin = null;
                DateTime? dtEnd = null;
    
                if (grid != null && grid.Children.OfType<System.Windows.Controls.Primitives.CalendarDayButton>().Any())
                {
                    foreach (var button in grid.Children.OfType<System.Windows.Controls.Primitives.CalendarDayButton>().Cast<System.Windows.Controls.Primitives.CalendarDayButton>())
                    {
                        if (dtBegin == null)
                            dtBegin = Convert.ToDateTime(button.Tag);
                        else
                            dtEnd = Convert.ToDateTime(button.Tag);
                    }
                }
            }
    
            public static T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    string controlName = child.GetValue(Control.NameProperty) as string;
                    if (controlName == name)
                    {
                        return child as T;
                    }
                    else
                    {
                        T result = FindVisualChildByName<T>(child, name);
                        if (result != null)
                            return result;
                    }
                }
                return null;
            }
