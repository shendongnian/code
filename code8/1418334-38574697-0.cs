    public partial class AutoCompleteComboBox : UserControl
        {
            private Window w;
            public AutoCompleteComboBox()
            {
                InitializeComponent();
            }
            ~AutoCompleteComboBox()
            {
                if(w == null)
                {
                    return;
                }
                else
                {
                    w.MouseLeftButtonDown -= Window_MouseLeftDown;
                }
                
            }
            
    
            #region Behaviours
            public void FocusTextBox()
            {
                txt.Focus();
                txt.CaretIndex = txt.Text.Length;
            }
            #endregion  
    
            #region DependencyProperties
            public static readonly DependencyProperty InputPaddingProperty =
                DependencyProperty.Register(
                    "InputPadding",
                    typeof(Thickness),
                    typeof(AutoCompleteComboBox)
                    );
            public Thickness InputPadding
            {
                get
                {
                    return (Thickness)GetValue(InputPaddingProperty);
                }
                set
                {
                    SetValue(InputPaddingProperty, value);
                }
            }
            public static readonly DependencyProperty TextBoxHeightProperty =
                DependencyProperty.Register(
                    "TextBoxHeight",
                    typeof(double),
                    typeof(AutoCompleteComboBox)
                    );
            public double TextBoxHeight
            {
                get
                {
                    return (double)GetValue(TextBoxHeightProperty);
                }
                set
                {
                    SetValue(TextBoxHeightProperty, value);
                }
            }
            public static readonly DependencyProperty ItemPanelMaxHeightProperty =
                DependencyProperty.Register(
                    "ItemPanelMaxHeight",
                    typeof(double),
                    typeof(AutoCompleteComboBox)
                    );
            public double ItemPanelMaxHeight
            {
                get
                {
                    return (double)GetValue(ItemPanelMaxHeightProperty);
                }
                set
                {
                    SetValue(ItemPanelMaxHeightProperty, value);
                }
            }
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register(
                    "ItemsSource",
                    typeof(IEnumerable),
                    typeof(AutoCompleteComboBox)
                    );
            public IEnumerable ItemsSource
            {
                get
                {
                    return (IEnumerable)ItemsSource;
                }
                set
                {
                    SetValue(ItemsSourceProperty, value);
                }
            }
            public static readonly DependencyProperty DisplayMemberPathProperty =
                DependencyProperty.Register(
                    "DisplayMemberPath",
                    typeof(string),
                    typeof(AutoCompleteComboBox)
                    );
            public string DisplayMemberPath
            {
                get
                {
                    return GetValue(DisplayMemberPathProperty).ToString();
                }
                set
                {
                    SetValue(DisplayMemberPathProperty, value);
                }
            }
            public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register(
                    "Text",
                    typeof(string),
                    typeof(AutoCompleteComboBox),
                    new FrameworkPropertyMetadata(
                        "",
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                        )
                    );
            public string Text
            {
                get
                {
                    return GetValue(TextProperty).ToString();
                }
                set
                {
                    SetValue(TextProperty, value);
                }
            }
            public string TargetValue { get; set; } = "";
            public static readonly DependencyProperty IsDropDownOpenProperty =
                DependencyProperty.Register(
                    "IsDropDownOpen",
                    typeof(bool),
                    typeof(AutoCompleteComboBox),
                    new FrameworkPropertyMetadata(
                        false,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                        )
                    );
            public bool IsDropDownOpen
            {
                get
                {
                    return (bool)GetValue(IsDropDownOpenProperty);
                }
                set
                {
                    SetValue(IsDropDownOpenProperty, value);
                }
            }
            #endregion
    
            #region Events
            private void me_Loaded(object sender, RoutedEventArgs e)
            {
                w = VisualTreeHelpers.FindAncestor<Window>(this);
                w.MouseLeftButtonDown += Window_MouseLeftDown;
                FocusTextBox();
            }
            private void Window_MouseLeftDown(object sender, MouseButtonEventArgs e)
            {
                IsDropDownOpen = false;
            }
            private void lst_KeyDown(object sender, KeyEventArgs e)
            {
            }
            private void lst_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (TargetValue != null && TargetValue.Trim().Length > 0)
                {
                    txt.Text = TargetValue;
                    IsDropDownOpen = false;
                }
                FocusTextBox();
            }
            private void lst_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
            }
            private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (lst.SelectedItem != null)
                {
                    TargetValue = lst.SelectedItem.ToString();
                }
            }
            private void txt_LostFocus(object sender, RoutedEventArgs e)
            {
                if (lst.IsFocused == false)
                {
                    IsDropDownOpen = false;
                    FocusTextBox();
                }
            }
            private void lst_LostFocus(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("text changed");
                if (txt.IsFocused == false)
                {
                    IsDropDownOpen = false;
                }
            }
            private void txt_TextChanged(object sender, TextChangedEventArgs e)
            {
                IsDropDownOpen = true;
            }
            private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (IsDropDownOpen && lst.Items.Count > 0)
                {
                    if (lst.SelectedIndex < 0)
                    {
                        lst.SelectedIndex = 0;
                    }
                    if (e.Key == Key.Up && lst.SelectedIndex > 0)
                    {
                        lst.SelectedIndex--;
                    }
                    else if (e.Key == Key.Down && lst.SelectedIndex < lst.Items.Count - 1)
                    {
                        lst.SelectedIndex++;
                    }
                    else if(e.Key == Key.Enter || e.Key == Key.Tab)
                    {
                        if(lst.SelectedIndex > -1)
                        {
                            txt.Text = TargetValue;
                            IsDropDownOpen = false;
                            FocusTextBox();
                        }
                    }
                    
                }
            }
    
            #endregion
        }
