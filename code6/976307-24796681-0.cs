    public partial class UserControl1 : WebBrowser
    {
        private string _text = string.Empty;
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override String Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.DocumentText = getContent(_text);
            }
        }
        private string getContent(string _value)
        {
            return string.Format("<HTML><marquee>{0}</marquee></HTML>", _value);
        }
        public UserControl1()
        {
            InitializeComponent();
        }
    }
