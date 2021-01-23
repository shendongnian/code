    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
             XmlDocument Doc = new XmlDocument();
             Doc.Load("YourPath to XML document");
             foreach (XmlNode node in Doc.DocumentElement.ChildNodes)
             {
                 if (node.Name == "sprite")
                 {
                     /*This code setup name of label, we take Attribute of parrent*/
                     Label lb = new Label();
                     lb.Content = node.Attributes.GetNamedItem("ParrentAttribute");
                     /*SPanel is added in MainWindow XAML it  is a ordinary Stack Panel you can dynamically create stack panel and just add to grid from code*/
                     SPanel.Children.Add(lb);
                     XmlNodeList SearchNode = node.ChildNodes;
                     /*Listing all child nodes to create check boxes */
                     foreach (XmlNode Child in SearchNode)
                     {
                         CheckBox cb = new CheckBox();
                         cb.Margin = new Thickness(20, 0, 0, 0);
                         cb.Content = Child.InnerText;
                         SPanel.Children.Add(cb);
                     }
                 }
             }
        }
    }
