        public string Placeholder { get; set; } // Using Fody.PropertyChanged to populate
        public bool IsPassword { get; set; } // the PropertyChanged(nameof(Property)) in the setters
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            propertyName: nameof(Text),
            returnType: typeof(string),
            declaringType: typeof(string),
            defaultValue: string.Empty);
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != Text)
            {
                Text = e.NewTextValue;
            }
        }
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            propertyName: nameof(TextColor),
            returnType: typeof(Color),
            declaringType: typeof(Color),
            defaultValue: Color.Black);
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch(propertyName)
            {
                case nameof(Placeholder):
                    EntryView.Placeholder = Placeholder;
                    break;
                case nameof(IsPassword):
                    EntryView.IsPassword = IsPassword;
                    break;
                case nameof(Text):
                    if(EntryView.Text != Text)
                        EntryView.Text = Text;
                    break;
                case nameof(TextColor):
                    EntryView.TextColor = TextColor;
                    break;
            }
        }
