            class NewPaymentEntry : Entry
    {
       public NewPaymentEntry()
        {
            base.TextChanged += EditText;
        }
        public void EditText(object sender, TextChangedEventArgs args)
        {
            Entry e = sender as Entry;
            String val = e.Text;
            if (string.IsNullOrEmpty(val))
                return;
            if (Uppercase )
                val = val.ToUpper();
            if(MaxLength > 0 && val.Length > MaxLength)
            {
                    val = val.Remove(val.Length - 1);
            }
            e.Text = val;
        }
        public static readonly BindableProperty UppercaseProperty = BindableProperty.Create<NewPaymentEntry, bool>(p => p.Uppercase, false);
        public bool Uppercase
        {
            get
            {
                return (bool)GetValue(UppercaseProperty);
            }
            set
            {
                SetValue(UppercaseProperty, value);
            }
        }
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create<NewPaymentEntry, int>(p => p.MaxLength, 0);
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }
    }
