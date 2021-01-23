    public class DataGridHelper : DependencyObject
    {
        public static List<bool> GetVisibilityList(
            DependencyObject obj)
        {
            return (List<bool>)obj.GetValue(VisibilityListProperty);
        }
        public static void SetVisibilityList(
            DependencyObject obj, List<bool> value)
        {
            obj.SetValue(VisibilityListProperty, value);
        }
        public static readonly DependencyProperty
            VisibilityListProperty =
            DependencyProperty.RegisterAttached("VisibilityList",
            typeof(List<bool>), typeof(DataGridHelper),
            new PropertyMetadata(VisibilityListChanged));
        private static void VisibilityListChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            var grid = d as DataGrid;
            if (grid == null) return;
            var visibilities = (List<bool>)grid.GetValue(VisibilityListProperty);
            foreach (var column in grid.Columns)
            {
                if ((bool)visibilities[column.DisplayIndex] == true)
                    column.Visibility = Visibility.Visible;
                else
                {
                    column.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
