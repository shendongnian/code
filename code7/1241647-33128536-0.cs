    public partial class MainWindow : Window
    {
        private ObservableCollection<ServerIssue> serverIssues;
        public MainWindow()
        {
            // Linq to XML for elegant Selections
            XElement doc = XElement.Load("serverissues.xml");
            var xmlServerIssues = from objectElt in doc.Descendants("Object")
                               let propertiesElts = objectElt.Elements("Property")
                               let serverElt = propertiesElts.FirstOrDefault(elt => elt.Attribute("Name").Value == "Server")
                               let issueElt = propertiesElts.FirstOrDefault(elt => elt.Attribute("Name").Value == "Issue")
                               select new ServerIssue {
                                   Server = ((serverElt.FirstNode) as XText).Value,
                                   Issue = ((issueElt.FirstNode) as XText).Value
                               };
            // store enumerated data in ObservableCollection<>
            // List<> would be fine but is less agile when adding/removing elements
            serverIssues = new ObservableCollection<ServerIssue>(xmlServerIssues);
            InitializeComponent();
            // Provide data to graphical Grid
            datagridIssues.ItemsSource = serverIssues;
        }
        private void SendToJIRA(object sender, RoutedEventArgs e)
        {
            // ...
        }
    }
