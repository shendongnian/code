      public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
    
            public event RoutedEventHandler LostFocusIgnoreChildren;
            private void UserControl_LostFocus(object sender, RoutedEventArgs e)
            {
                var focused_element = FocusManager.GetFocusedElement(Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive));
                var parent = (focused_element as FrameworkElement).TryFindParent<UserControl1>();
                if (parent == null && LostFocusIgnoreChildren != null)
                    LostFocusIgnoreChildren(this, e);
            }
        }
