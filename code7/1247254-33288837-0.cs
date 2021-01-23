    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApplicationViewToViewModel
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public UserControl1()
            {
                InitializeComponent();
                this.DataContext = new UserControl1ViewModel(); 
                /*
                [Bridge Binding ©]
                It's not possible to bind 3 properties.
                So this bridge binding handles the communication
                */
                string propertyInViewModel = "TextInUserControlViewModel";
                var bindingViewMode = new Binding(propertyInViewModel);
                bindingViewMode.Mode = BindingMode.TwoWay;
                this.SetBinding(BridgeBetweenUCandVWProperty, bindingViewMode);
    
    
            }
            #region Bridge Property
            public static DependencyProperty BridgeBetweenUCandVWProperty =
                DependencyProperty.Register("BridgeBetweenUCandVW",
            typeof(string),
            typeof(UserControl1),
            new PropertyMetadata(BridgeBetweenUCandVWPropertyChanged)
            );
    
            public string BridgeBetweenUCandVW
            {
                get
                {
                    return (string)GetValue(BridgeBetweenUCandVWProperty);
                }
                set
                {
                    this.SetValue(BridgeBetweenUCandVWProperty, value);
                }
            }
    
            private static void BridgeBetweenUCandVWPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((UserControl1)d).TextInUserControl = (string)e.NewValue;
            }
            #endregion
    
            #region TextInUserControl Property
            public static DependencyProperty TextInUserControlProperty =
                DependencyProperty.Register("TextInUserControl",
                    typeof(string),
                    typeof(UserControl1),
                    new PropertyMetadata(OnTextInUserControlPropertyChanged)
                    );
    
            private static void OnTextInUserControlPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((UserControl1ViewModel)((UserControl)d).DataContext).TextInUserControlViewModel = (string)e.NewValue;
            }
    
            public string TextInUserControl
            {
                get {
                   return (string)GetValue(TextInUserControlProperty);
                }
                set
                {
                    this.SetValue(TextInUserControlProperty, value);
                }
            }
            #endregion
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                TextInUserControl += "[UC]";
                MessageBox.Show("TextInUserControl : " + TextInUserControl);
            }
        }
    }
