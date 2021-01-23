    /// <summary>
    /// Interaction logic for MyToolBarButton.xaml
    /// </summary>
    public partial class MyToolBarButton : UserControl
    {
        public MyToolBarButton()
        {
            InitializeComponent();
        }
          #region Dependency Properties.
        /// <summary>
        /// Dependency property for the <see cref="IsVisible"/> property.
        /// </summary>
        public static DependencyProperty IsVisibleProperty = DependencyProperty.Register("IsVisible", typeof(bool), typeof(MyOldToolBarButton),
                                                                                                     new FrameworkPropertyMetadata(true,
                                                                                                                               FrameworkPropertyMetadataOptions
                                                                                                                               .BindsTwoWayByDefault, Visible_Changed));
        /// <summary>
        /// Dependency property for the <see cref="IsEnabled"/> property.
        /// </summary>
        public static DependencyProperty IsEnabledProperty = DependencyProperty.Register("IsEnabled", typeof(bool), typeof(MyOldToolBarButton),
                                                                                         new FrameworkPropertyMetadata(true,
                                                                                                                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, Enabled_Changed));
        /// <summary>
        /// Dependency property for the <see cref="ToolTip"/> property.
        /// </summary>
        public static DependencyProperty ToolTipProperty = DependencyProperty.Register("ToolTip", typeof(string), typeof(MyOldToolBarButton),
                                                                                         new FrameworkPropertyMetadata(string.Empty,
                                                                                                                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                                                                                                          new PropertyChangedCallback(ToolTipPropertyChanged)));
        private static void ToolTipPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Dependency property for the <see cref="Glyph"/> property.
        /// </summary>
        public static DependencyProperty GlyphProperty = DependencyProperty.Register("Glyph", typeof(ImageSource), typeof(MyOldToolBarButton),
                                                                                         new FrameworkPropertyMetadata(null,
                                                                                                                       FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, Glyph_Changed));
        /// <summary>
        /// Dependency property for the <see cref="ID"/> property.
        /// </summary>
        public static DependencyProperty IDProperty = DependencyProperty.Register("ID", typeof(string), typeof(MyOldToolBarButton),
                                                                                  new FrameworkPropertyMetadata(string.Empty,
                                                                                                                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        /// <summary>
        /// Dependency property for the <see cref="ClickedCommand"/> property.
        /// </summary>
        public static DependencyProperty ClickedCommandProperty = DependencyProperty.Register("ClickedCommand", typeof(string),
            typeof(MyOldToolBarButton),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        #endregion
        #region Variables.
        // The default image source for the button glyph.
        public Uri _defaultImageSource { private set; get; }
        #endregion
        #region Properties.
        /// <summary>
        /// Property to set or return the ID of the button.
        /// </summary>
        [Category("Configuration")]
        public string ID
        {
            get
            {
                object value = GetValue(IDProperty);
                return value == null ? string.Empty : value.ToString();
            }
            set
            {
                SetValue(IDProperty, value);
            }
        }
        /// <summary>
        /// Property to set or return the glyph for this button.
        /// </summary>
        [Category("Configuration")]
        public ImageSource Glyph
        {
            get
            {
                return GetValue(GlyphProperty) as ImageSource;
            }
            set
            {
                SetValue(GlyphProperty, value);
            }
        }
        /// <summary>
        /// Property to set or return the tool tip for the button.
        /// </summary>
        /// 
        [Category("Configuration")]
        public string ToolTip
        {
            get
            {
                object value = GetValue(ToolTipProperty);
                return value == null ? string.Empty : value.ToString();
            }
            set
            {
                SetValue(ToolTipProperty, value);
            }
        }
        /// <summary>
        /// Property to set or return whether the button is visible or not.
        /// </summary>
        /// 
        [Category("Configuration")]
        public bool IsVisible
        {
            get
            {
                return (bool)GetValue(IsVisibleProperty);
            }
            set
            {
                SetValue(IsVisibleProperty, value);
            }
        }
        /// <summary>
        /// Property to set or return whether the button is enabled or not.
        /// </summary>
        /// 
        [Category("Configuration")]
        public bool IsEnabled
        {
            get
            {
                return (bool)GetValue(IsEnabledProperty);
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }
        #endregion
        #region Methods.
        /// <summary>
        /// Function to handle a change to the <see cref="GlyphProperty"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void Glyph_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // TODO
        }
        /// <summary>
        /// Function to handle a change to the <see cref="IsVisibleProperty"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void Visible_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // TODO
        }
        /// <summary>
        /// Function to handle a change to the <see cref="IsEnabledProperty"/>.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void Enabled_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // TODO
        }
        /// <summary>
        /// When implemented in a derived class, creates a new instance of the <see cref="T:System.Windows.Freezable" /> derived class.
        /// </summary>
        /// <returns>The new instance.</returns>
        protected  Freezable CreateInstanceCore()
        {
            return new MyOldToolBarButton();
        }
        #endregion
        #region Constructor/Finalizer.
        /// <summary>
        /// Initializes a new instance of the <see cref="MyOldToolBarButton"/> class.
        /// </summary>
        /// <param name="buttonID">The ID of the button being clicked.</param>
        /// <param name="defaultImageSource">The default image source URI for the glyph used by the button.</param>
        internal void MyOldToolBarButton(string buttonID, string defaultImageSource)
        {
            ID = buttonID;
            IsVisible = true;
            IsEnabled = true;
            ToolTip = string.Empty;
            if (!string.IsNullOrWhiteSpace(defaultImageSource))
            {
                _defaultImageSource = new Uri(defaultImageSource, UriKind.Relative);
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MyOldToolBarButton"/> class.
        /// </summary>
        public void MyOldToolBarButton()
        {
            // This is here to keep the XAML designer from complaining.         
        }
        #endregion
    }
