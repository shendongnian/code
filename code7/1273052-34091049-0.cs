    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            var cb1 = Manager.SharedInstance.GetDatabase("cb1");
            cb1.Changed += Cb1_Changed;
            var cb2 = Manager.SharedInstance.GetDatabase("cb2");
            cb2.Changed += Cb2_Changed;
            string url = "http://try-cb.cloudapp.net:4984/sync_gateway/";
            var auth = new Couchbase.Lite.Auth.BasicAuthenticator("couchbase", "letmein");
            var push = cb1.CreatePushReplication(new Uri(url));
            push.Continuous = true;
            push.Authenticator = auth;
            push.Start();
            var pull = cb2.CreatePullReplication(new Uri(url));
            pull.Continuous = true;
            pull.Authenticator = auth;
            pull.Start();
        }
        private void Cb2_Changed(object sender, DatabaseChangeEventArgs e)
        {
            var cb2 = Manager.SharedInstance.GetDatabase("cb2");
            var docs = e.Changes
                .Select(id => cb2.GetDocument(id.DocumentId))
                .ToList();
            Debugger.Break();
        }
        private void Cb1_Changed(object sender, DatabaseChangeEventArgs e)
        {
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var cb1 = Manager.SharedInstance.GetDatabase("cb1");
            var doc = cb1.CreateDocument();
            var props = doc.UserProperties != null ? doc.Properties : new Dictionary<string, object>();
            props["doc"] = new
            {
                type = "test",
                guid = Guid.NewGuid().ToString()
            };
            doc.PutProperties(props);
        }
    }
