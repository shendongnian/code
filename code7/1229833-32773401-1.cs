    public enum ETestEnum
    {
        Value1,
        Value2,
    }
    public partial class MainWindow : Window
    {
        public ETestEnum EnumValue
        {
            get { return (ETestEnum)GetValue(EnumValueProperty); }
            set { SetValue(EnumValueProperty, value); }
        }
        public static readonly DependencyProperty EnumValueProperty =
            DependencyProperty.Register("EnumValue", typeof(ETestEnum), typeof(MainWindow), new PropertyMetadata(ETestEnum.Value1));
                
        public MainWindow()
        {
            InitializeComponent();
            foreach (ETestEnum value in Enum.GetValues(typeof(ETestEnum)))
            {
                this.combobox.Items.Add(value);
            }            
            Binding binding = new Binding();
            binding.Source = this;
            binding.Path = new PropertyPath("EnumValue");
            this.combobox.SetBinding(ComboBox.SelectedValueProperty, binding);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnumValue = EnumValue == ETestEnum.Value1 ? ETestEnum.Value2 : ETestEnum.Value1;
        }
    }
