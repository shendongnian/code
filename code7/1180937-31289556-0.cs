        public partial class SomeView : UserControl
        {
        private List<Button> ButtonCollection;
        private List<TextBox> TargetCollection;
        public SomeView()
        {
            InitializeComponent();
            ButtonCollection = new List<Button>
            {
                Button1,
                Button2,
                Button3
            };
            TargetCollection = new List<TextBox>
            {
                OutputTextBox1,
                OutputTextBox2,
                OutputTextBox3
            };
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var index = ButtonCollection.IndexOf(sender as Button);
            if (index >= 0)
            {
                var target = TargetCollection[index];
                ...
            }
        }
        }
