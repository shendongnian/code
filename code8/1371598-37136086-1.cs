        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TextChangedBehavior), null);
        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (Command != null)
                Command.Execute(null);
        }
