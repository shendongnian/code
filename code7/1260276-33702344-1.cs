    public partial class FanoutButton : UserControl
        {
            private string _mainText;
            private Popup _fanoutPopup;
    
            public string MainText { get { return _mainText; } set { SetMainText(value); } }
    
            public List<string> Variations { get; set; }
    
            public delegate void ValueClickedHandler(string value);
            public event ValueClickedHandler ValueClicked;
    
            public FanoutButton()
            {
                InitializeComponent();
                InitializeVariables();
            }
    
            private void InitializeVariables()
            {
                this.Variations = new List<string>();
            }
    
            private void SetMainText(string value)
            {
                _mainText = value;
    
                btnMain.Content = _mainText;
            }
    
            private void Hold()
            {
                //Calculate rows and columns for popup
                int buttonCount = 1 + this.Variations.Count;
                double squareRoot = Math.Sqrt((double)buttonCount);
                int columns = (int)Math.Ceiling(squareRoot);
                int rows = (int)Math.Round(squareRoot);
    
                int width = (int)this.Width * columns;
                int height = (int)this.Height * rows;
    
                //Get button location
                Point buttonPosition = btnMain.PointToScreen(new Point(0d, 0d));
    
                _fanoutPopup = new Popup();
                _fanoutPopup.Width = width;
                _fanoutPopup.Height = height;
                _fanoutPopup.HorizontalOffset = buttonPosition.X;
                _fanoutPopup.VerticalOffset = buttonPosition.Y;
    
    
                var allValues = new List<string>();
                allValues.Add(_mainText);
                allValues.AddRange(this.Variations);
    
                var container = new WrapPanel();
                _fanoutPopup.Child = container;
    
                foreach (string value in allValues)
                {
                    var button = new Button();
                    button.Width = this.Width;
                    button.Height = this.Height;
                    button.Content = value;
                    button.Background = btnMain.Background;
                    button.Foreground = btnMain.Foreground;
                    button.Template = btnMain.Template;
                    button.Tag = value;
                    button.Click += button_Click;
    
                    container.Children.Add(button);
                }
    
                _fanoutPopup.IsOpen = true;
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                string value = "";
    
                if (sender is Button)
                {
                    value = ((Button)sender).Tag.ToString();
    
                    _fanoutPopup.IsOpen = false;
    
                    RaiseValueClicked(value);
                }
            }
    
            private void btnMain_Click(object sender, RoutedEventArgs e)
            {
                Hold();
            }
    
            private void RaiseValueClicked(string value)
            {
                if (ValueClicked != null)
                {
                    ValueClicked(value);
                }
            }
    }
