    internal class MyObjectSelectionChangedToCommand
    {
        public static readonly DependencyProperty SelectionCommandProperty =
            DependencyProperty.RegisterAttached("SelectionCommand", typeof(DelegateCommand<GridSelectionInfo<MyObject>>),
            typeof(ResourceCardGridSelectionChangedToCommand), new PropertyMetadata(null, OnSelectionCommandChanged));
        public static DelegateCommand<GridSelectionInfo<MyObject>> GetSelectionCommand(DependencyObject obj)
        {
            return (DelegateCommand<GridSelectionInfo<MyObject>>)obj.GetValue(SelectionCommandProperty);
        }
        public static void SetSelectionCommand(DependencyObject obj, DelegateCommand<GridSelectionInfo<MyObject>> value)
        {
            obj.SetValue(SelectionCommandProperty, value);
        }
        private static void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tsci = new GridSelectionInfo<MyObject>
            {
                Added = e.AddedItems.Cast<MyObject>().ToList(),
                Removed = e.RemovedItems.Cast<MyObject>().ToList(),
                Selected = ((ListBox)sender).SelectedItems.Cast<MyObject>().ToList()
            };
            var cmd = GetSelectionCommand((DependencyObject)sender);
            cmd.Execute(tsci);
        }
        private static void OnSelectionCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dg = d as ListBox;
            if (dg != null) dg.SelectionChanged += dg_SelectionChanged;
        }
    }
    public class GridSelectionInfo<T>
    {
        public GridSelectionInfo()
        {
            Selected = new List<T>();
            Added = new List<T>();
            Removed = new List<T>();
        }
        public List<T> Added { get; set; }
        public List<T> Removed { get; set; }
        public List<T> Selected { get; set; }
        public override string ToString()
        {
            return string.Format("Added: {0}, Removed: {1}, Selected: {2}", Added.Count, Removed.Count, Selected.ToFormattedString());
        }
    }
