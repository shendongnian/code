    namespace MyControls
    {
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
            }
            #region Dependency Properties
            public static readonly DependencyProperty DynamicUserControlProperty = DependencyProperty.Register("DynamicUserControl", typeof(object), typeof(UserControl1), null);
            public object DynamicUserControl
            {
                get
                {
                    return GetValue(DynamicUserControlProperty);
                }
                set
                {
                    SetValue(DynamicUserControlProperty, value);
                }
            }
            #endregion
        }
    }
