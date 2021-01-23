    public partial class PlaceHolder : UserControl
    {
        private bool m_isReadOnly;
        private object m_PlaceholdeContent;
        private bool m_hasValue;
        private object m_realContent;
        public PlaceHolder()
        {
            InitializeComponent();
            GotFocus += OnGotFocus;
        }
        private void OnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            GotFocus -= OnGotFocus;
            if (!RealContentIsUsed)
            {
                RealContentIsUsed = true;
                Content = RealContent;
            }
        }
        private bool RealContentIsUsed { get; set; }
        public object RealContent
        {
            get { return m_realContent; }
            set
            {
                m_realContent = value;
                if (IsReadOnly || HasValue)
                {
                    Content = m_realContent;
                }
            }
        }
        public object PlaceholdeContent
        {
            get { return m_PlaceholdeContent; }
            set
            {
                m_PlaceholdeContent = value;
                if (!RealContentIsUsed)
                {
                    Content = m_PlaceholdeContent;
                }
            }
        }
        public bool IsReadOnly
        {
            get { return m_isReadOnly; }
            set
            {
                m_isReadOnly = value;
                if (value && !RealContentIsUsed)
                {
                    Content = RealContent;
                    RealContentIsUsed = true;
                }
            }
        }
        public bool HasValue
        {
            get { return m_hasValue; }
            set
            {
                m_hasValue = value;
                if (HasValue && RealContentIsUsed == false)
                {
                    Content = RealContent;
                    RealContentIsUsed = true;
                }
            }
        }
    }
