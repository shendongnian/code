    public class SelectableObject : DependencyObject
    {
        public SelectableObject(string name)
        {
            Name = name;
        }
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected",
            typeof (bool), typeof (SelectableObject), new FrameworkPropertyMetadata());
        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public string Name { get; set; }
    }
