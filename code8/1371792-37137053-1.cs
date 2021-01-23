    public partial class SpecialTextPresenterWithButton : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof (string),
            typeof (SpecialTextPresenterWithButton), new PropertyMetadata(default(string)));
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register("DeleteCommand",
            typeof (ICommand), typeof (SpecialTextPresenterWithButton), new PropertyMetadata(default(ICommand)));
        public SpecialTextPresenterWithButton()
        {
            InitializeComponent();
        }
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public ICommand DeleteCommand
        {
            get { return (ICommand) GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
    }
