    public sealed partial class BusyIndicator : UserControl
    {
        private Popup ParentPopup = null;
        public BusyIndicator(string title = "Loading...", SolidColorBrush backgroundColor = null, SolidColorBrush foregroundColor = null)
        {
            this.InitializeComponent();
            TitleTextBlock.Text = title;
            this.Text = title;
            if (backgroundColor != null)
                this.gridBackground.Background = backgroundColor;
            if (foregroundColor != null)
            {
                this.progressRing.Foreground = foregroundColor;
                this.TitleTextBlock.Foreground = foregroundColor;
            } 
        }
        static SolidColorBrush def = Application.Current.Resources["SystemControlBackgroundAccentBrush"] as SolidColorBrush;
        #region Public Methods
        /// <summary>
        /// Closes the BusyIndicator.
        /// </summary>
        public void Close()
        {
            // Close the parent; closes the dialog too.
           // ((Popup)Parent).IsOpen = false;
           if(this.ParentPopup!= null && this.ParentPopup.IsOpen == true)
                this.ParentPopup.IsOpen = false;
        }
        #endregion Public Methods
        #region Public Static Methods
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(500) };
        /// <summary>
        /// Locks the screen ans starts the BusyIndicator by creating a popup.
        /// </summary>
        /// <param name="title">The title to be displayed by the BusyIndicator.</param>
        /// <returns>The BusyIndicator.</returns>
        public void Start()
        {
            // Create a popup with the size of the app's window.
            Popup popup = new Popup()
            {
                Height = Window.Current.Bounds.Height,
                IsLightDismissEnabled = false,
                Width = Window.Current.Bounds.Width
            };
            // Create the BusyIndicator as a child, having the same size as the app.
            BusyIndicator busyIndicator = new BusyIndicator()
            {
                Height = popup.Height,
                Width = popup.Width,
                Text = this.Text,
            };
            this.timer.Start();
            this.timer.Tick += (f, y) =>
            {
                busyIndicator.Text = Text;
            };
            // Set the child of the popop
            popup.Child = busyIndicator;
            // Postion the popup to the upper left corner
            popup.SetValue(Canvas.LeftProperty, 0);
            popup.SetValue(Canvas.TopProperty, 0);
            // Open it.
            this.ParentPopup = popup;
            popup.IsOpen = true;
           
            // Return the BusyIndicator
           // return (busyIndicator);
        }
        //string
        public static readonly DependencyProperty SetMessageProperty = DependencyProperty.Register("Text", typeof(string),
            typeof(BusyIndicator), new PropertyMetadata("Loading...", new PropertyChangedCallback(OnMessageTextChanged)));
        public string Text
        {
            get { return (string)GetValue(SetMessageProperty); }
            set { SetValue(SetMessageProperty, value); }
        }
        private static void OnMessageTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BusyIndicator borderControl = d as BusyIndicator;
            borderControl.OnMessageTextChanged(e);
        }
        private void OnMessageTextChanged(DependencyPropertyChangedEventArgs e)
        {
            this.TitleTextBlock.Text = e.NewValue.ToString();
        }
        //string
        public static readonly DependencyProperty SetColorProperty = DependencyProperty.Register("SetColor", typeof(SolidColorBrush),
            typeof(BusyIndicator), new PropertyMetadata(Colors.Green, new PropertyChangedCallback(OnColorTextChanged)));
        public SolidColorBrush SetColor
        {
            get { return (SolidColorBrush)GetValue(SetColorProperty); }
            set { SetValue(SetColorProperty, value); }
        }
        private static void OnColorTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BusyIndicator borderControl = d as BusyIndicator;
            borderControl.OnColorTextChanged(e);
        }
        private void OnColorTextChanged(DependencyPropertyChangedEventArgs e)
        {
            this.TitleTextBlock.Foreground =(SolidColorBrush) e.NewValue;
            this.progressRing.Foreground = (SolidColorBrush)e.NewValue;
        }
    }
