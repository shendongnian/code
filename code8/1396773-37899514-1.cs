    namespace ApplicationName.Controls
    {
        public partial class EntryControl : Grid
        {
            public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(EntryControl),
                defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay);
            public string Command
            {
                get { return (string)this.GetValue(CommandProperty); }
                set { this.SetValue(CommandProperty, value); }
            }
            public EntryControl()
            {
                InitializeComponent();
            }
        }
    }
