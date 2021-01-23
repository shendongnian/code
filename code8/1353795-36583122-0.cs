    public class ExportOnDoubleClickBehavior
    {
        // This is the attached property
        public static string GetExportPath(DependencyObject obj)
        {
            return (string)obj.GetValue(ExportPathProperty);
        }
        public static void SetExportPath(DependencyObject obj, string value)
        {
            obj.SetValue(ExportPathProperty, value);
        }
        // Using a DependencyProperty as the backing store for ExportPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExportPathProperty =
            DependencyProperty.RegisterAttached("ExportPath", typeof(string), typeof(ExportOnDoubleClickBehavior), new PropertyMetadata(string.Empty, PathChanged));
        // Here we are registering to the double click event of the grid.
        // Change the registration to the relevant event.
        private static void PathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadGridView grid = d as RadGridView;
            if (RadGridView == null)
                throw new InvalidCastException("ExportOnDoubleClickBehavior can be set only on RadGridView.");
            // Change to relevant event HERE
            grid.DoubleClick += ExportGridToExcel;
        }
        // Here we will export the grid to excel.
        // Again, change to relevant method
        private static void ExportGridToExcel(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            RadGridView grid = sender as RadGridView;
            if (grid == null)
                throw new InvalidCastException("ExportOnDoubleClickBehavior can be set only on RadGridView.");
            string exportPath = GetExportPath(grid);
            grid.ExportToExcel(exportPath); // HERE!!!
        }
    }
