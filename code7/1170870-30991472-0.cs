    public partial class Form1 : Form
    {
        private Awesomium.Windows.Forms.WebControl webControl1;
        public Form1()
        {
            if (!WebCore.IsInitialized)
            {
                WebCore.Initialize(new WebConfig(), true);
            }
            InitializeComponent();
            this.webControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Size = new System.Drawing.Size(1134, 681);
            this.webControl1.TabIndex = 0;
            this.webControl1.WebSession = WebCore.CreateWebSession("%APPDATA%\\Test", new WebPreferences
            {
                CustomCSS = "body { overflow:hidden; }",
                WebSecurity = false,
                DefaultEncoding = "UTF-8",
            });
            this.webControl1.Source = new Uri("http://localhost:8080/Test/test.html");
        }
    }
