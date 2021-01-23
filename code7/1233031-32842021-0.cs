    public class ViewModel : DependencyObject
        {
            public bool  UseCurrentWindowsUser
            {
                get { return (bool )GetValue(UseCurrentWindowsUserProperty); }
                set { SetValue(UseCurrentWindowsUserProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for UseCurrentWindowsUser.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty UseCurrentWindowsUserProperty =
                DependencyProperty.Register("UseCurrentWindowsUser", typeof(bool ), typeof(ViewModel), new PropertyMetadata(null));
            
        }
