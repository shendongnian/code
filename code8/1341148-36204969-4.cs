        #region TextBoxA Property
        public TextBox TextBoxA
        {
            get { return (TextBox)GetValue(TextBoxAProperty); }
            set { SetValue(TextBoxAProperty, value); }
        }
        public static readonly DependencyProperty TextBoxAProperty =
            DependencyProperty.Register("TextBoxA", typeof(TextBox), 
                typeof(TextBoxLinkerAdorner),
                new FrameworkPropertyMetadata(null,
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                        TextBoxA_PropertyChanged)
                            { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
        protected static void TextBoxA_PropertyChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            var obj = d as TextBoxLinkerAdorner;
        }
        #endregion TextBoxA Property
