    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
            var _content = new UserSettingsView();
            ContentControl.Content = _content;
            this.MinWidth = _content.MinWidth;
            this.MinHeight=_content.MinHeight;
            this.Width=this.MinWidth;
            this.Height=this.MinHeight;
        }
    }
