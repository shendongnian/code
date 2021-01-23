    public partial class EditableLabel : Label
    {
        #region DependencyProperties
        public static readonly DependencyProperty IsEditingProperty =
            DependencyProperty.Register("IsEditing", typeof(bool), typeof(EditableLabel),
            new UIPropertyMetadata(false, IsEditingUpdate));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(EditableLabel),
             new FrameworkPropertyMetadata("",
                 FrameworkPropertyMetadataOptions.AffectsRender |
                 FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                 FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        private string m_lastValue = "";
        private IInputElement m_lastFocus = null;
        private Label m_label = null;
        private TextBox m_textBox = null;
        #endregion
        static EditableLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableLabel),
                new FrameworkPropertyMetadata(typeof(EditableLabel)));
        }
        public EditableLabel()
        {
            LostFocus += (s, e) => { };
            LostKeyboardFocus += EditableLabel_LostKeyboardFocus;
        }
        private void EditableLabel_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (e.NewFocus != null)
                Debug.WriteLine(e.NewFocus.GetType().Name);
        }
        public override void OnApplyTemplate()
        {
            m_label = GetTemplateChild("label") as Label;
            m_textBox = GetTemplateChild("textbox") as TextBox;
            m_label.MouseUp += Label_MouseUp;
            m_textBox.LostFocus += (s, e) => IsEditing = false;
            m_textBox.KeyUp += (s, e) => { TextBox_KeyUp(s, e); e.Handled = true; };
            m_textBox.GotKeyboardFocus += (s, e) => m_textBox.SelectAll();
            base.OnApplyTemplate();
        }
        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DependencyObject scope = FocusManager.GetFocusScope(this);
            IInputElement currFocus = FocusManager.GetFocusedElement(scope);
            if ((currFocus != null))
            {
                if (currFocus == m_lastFocus)
                {
                    IsEditing = true;
                }
                else
                {
                    m_lastFocus = currFocus;
                    DependencyObject observedObject = currFocus as DependencyObject;
                    if (observedObject != null)
                    {
                        m_lastFocus.LostKeyboardFocus += ObservedElementLostFocus;
                        m_lastFocus.KeyUp += ObservedElement_KeyUp; // THIS IS THE TRICK
                    }
                }
            }
        }
        private void ObservedElement_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                IsEditing = true;
                e.Handled = true;
            }
        }
        private void ObservedElementLostFocus(object sender, RoutedEventArgs e)
        {
            KeyboardFocusChangedEventArgs kfc = e as KeyboardFocusChangedEventArgs;
            if (kfc.NewFocus != null)
            {
                if ((kfc.NewFocus != m_textBox) && (kfc.NewFocus != m_lastFocus))
                {
                    m_lastFocus.LostKeyboardFocus -= ObservedElementLostFocus;
                    m_lastFocus.KeyUp -= ObservedElement_KeyUp;
                    m_lastFocus = null;
                }
            }
        }
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                IsEditing = false;
                Text = m_lastValue;
            }
            else if (e.Key == Key.Enter)
            {
                IsEditing = false;
            }
        }
        private static void IsEditingUpdate(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            EditableLabel self = obj as EditableLabel;
            if ((bool)e.NewValue)
            {
                self.m_lastValue = self.Text;
                self.m_textBox.Visibility = Visibility.Visible;
                self.m_textBox.Focus();
                self.m_label.Visibility = Visibility.Collapsed;
            }
            else
            {
                self.m_textBox.Visibility = Visibility.Collapsed;
                self.m_label.Visibility = Visibility.Visible;
                if (self.m_lastFocus != null)
                    self.m_lastFocus.Focus();
            }
        }
    }
