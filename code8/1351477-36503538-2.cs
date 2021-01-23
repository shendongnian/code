    public CustomComboBox : RadComboBox
    {
        public static readonly DependencyProperty MyIdxProperty = DependencyProperty.Register("MyIdx", typeof(object), typeof(CustomComboBox), null);
        public object MyIdx
        {
            get
            {
                return GetValue(MyIdxProperty);
            }
            set
            {
                SetValue(MyIdxProperty, value);
            }
        }
        //etc. etc.
    }
