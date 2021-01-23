    public static class CalendarM
    {
        private static Button tempButton;
        public static bool GetRemoveProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(RemoveFocusProperty);
        }
        public static void SetRemoveProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(RemoveFocusProperty, value);
        }
        public static readonly DependencyProperty RemoveFocusProperty = DependencyProperty.RegisterAttached("RemoveFocus", typeof(bool), typeof(CalendarM),
            new FrameworkPropertyMetadata(new PropertyChangedCallback((x, y) =>
            {
                if (x is Calendar && GetRemoveProperty((DependencyObject)x))
                {
                    tempButton = new Button() { Width = 0, Height = 0 };
                    ((System.Windows.Controls.Panel)((FrameworkElement)x).Parent).Children.Add(tempButton);
                    tempButton.Click += (s1, s2) =>
                    {
                    };
                    ((Calendar)x).SelectedDatesChanged += CalendarM_SelectedDatesChanged;
                }
            })));
        static void CalendarM_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            tempButton.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left) { RoutedEvent = Button.MouseDownEvent });
        }
    }
