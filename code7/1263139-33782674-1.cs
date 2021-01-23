    public class ManagedTabItem : TabItem
    {
        public IManager Manager
        {
            get { return (IManager)GetValue(ManagerProperty); }
            set { SetValue(ManagerProperty, value); }
        }
        public static readonly DependencyProperty ManagerProperty =
            DependencyProperty.Register("Manager", typeof(IManager), typeof(ManagedTabItem), new PropertyMetadata(null));
        static ManagedTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ManagedTabItem), new FrameworkPropertyMetadata(typeof(ManagedTabItem)));
        }
    }
