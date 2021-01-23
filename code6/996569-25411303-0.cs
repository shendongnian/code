    public class AutoCompleteComboBox : AutoCompleteBox
    {
        /// <summary>
        /// Occurs when drop down toggle button is clicked.
        /// </summary>
        public event EventHandler ToggleButtonClick;
        private object _holdSelectedItem;
        private AutoCompleteFilterMode _holdFilterMode;
        /// <summary>
        /// Identifies the DisplayMemberPath dependency property.
        /// </summary>
        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(AutoCompleteComboBox), new PropertyMetadata(string.Empty, DisplayMemberPath_PropertyChanged));
        /// <summary>
        /// Gets or sets the name or path of the property 
        /// that is displayed for each the data item in the control.
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
        private static void DisplayMemberPath_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var accb = (AutoCompleteComboBox)d;
            accb.ValueMemberPath = e.NewValue.ToString();
        }
        /// <summary>
        /// Identifies the MaxLength dependency property.
        /// </summary>
        public static readonly DependencyProperty MaxLengthProperty = DependencyProperty.Register("MaxLength", typeof(int), typeof(AutoCompleteComboBox), null);
        /// <summary>
        /// Gets or sets the maximum number of characters allowed for user input.
        /// </summary>
        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }
        /// <summary>
        /// Gets or sets a collection used to generate the content of the control.
        /// </summary>
        public new IEnumerable ItemsSource
        {
            get { return GetValue(ItemsSourceProperty) as IEnumerable; }
            set
            {
                SetValue(SelectedItemProperty, null);
                SetValue(ItemsSourceProperty, value);
                Dispatcher.BeginInvoke(() => SetValue(TextProperty, string.Empty));
                _holdSelectedItem = null;
            }
        }
        /// <summary>
        /// Initializes a new instance of the AutoComboBox control.
        /// </summary>
        public AutoCompleteComboBox()
        {
            StreamResourceInfo sri = Application.GetResourceStream(new Uri("/UI.Controls;component/AutoCompleteComboBox.xaml", UriKind.Relative));
            var sr = new StreamReader(sri.Stream);
            Style = (Style)XamlReader.Load(sr.ReadToEnd());
            DropDownClosed += AutoCompleteComboBox_DropDownClosed;
            DropDownOpened += AutoCompleteComboBox_DropDownOpened;
        }
        /// <summary>
        /// Called when the template's tree is generated.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var toggle = (ToggleButton)GetTemplateChild("PopupToggleButton");
            toggle.Click += DropDownToggle_Click;
            var lb = (ListBox)GetTemplateChild("Selector");
            lb.DisplayMemberPath = DisplayMemberPath;
            _holdFilterMode = FilterMode;
            TextChanged += AutoCompleteComboBox_TextChanged;
            SelectionChanged += new SelectionChangedEventHandler(AutoCompleteComboBox_SelectionChanged);
        }
        private void AutoCompleteComboBox_DropDownClosed(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (SelectedItem == null && _holdSelectedItem != null && SelectedItem != _holdSelectedItem && ItemsSource.Cast<object>().Contains(_holdSelectedItem))
            {
                SelectedItem = _holdSelectedItem;
            }
            _holdSelectedItem = null;
            FilterMode = _holdFilterMode;
        }
        private void AAutoCompleteComboBox_DropDownOpened(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            var lb = (ListBox)GetTemplateChild("Selector");
            ScrollViewer sv = lb.GetScrollHost();
            if (sv != null)
            {
                sv.ScrollToTop();
            }
            if (SelectedItem != null)
            {
                lb.SelectedItem = SelectedItem;
                _holdSelectedItem = SelectedItem;
            }
        }
        private void DropDownToggle_Click(object sender, RoutedEventArgs e)
        {
            IsDropDownOpen = !IsDropDownOpen;
            if (ToggleButtonClick != null)
            {
                ToggleButtonClick(this, e);
            }
            if (IsDropDownOpen)
            {
                _holdFilterMode = FilterMode;
                FilterMode = AutoCompleteFilterMode.None;
                ((TextBox)GetTemplateChild("Text")).SelectAll();
            }
            Focus();
        }
        private void AutoCompleteComboBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (IsDropDownOpen)
            {
                if (FilterMode == AutoCompleteFilterMode.None && FilterMode != _holdFilterMode)
                {
                    FilterMode = _holdFilterMode;
                }
                ScrollViewer sv = ((ListBox)GetTemplateChild("Selector")).GetScrollHost();
                if (sv != null)
                {
                    sv.ScrollToTop();
                }
            }
        }
        private void AutoCompleteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsDropDownOpen && SelectedItem == null)
            {
                Text = string.Empty;
            }
        }
    }
