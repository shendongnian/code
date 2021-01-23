    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public List<IElement> Elements
        {
            get
            {
                var list = new List<IElement>();
                list.Add(BuildContainer());
                list.Add(BuildContainer());
                list.Add(new Element());
                return list;
            }
        }
        private Container BuildContainer()
        {
            var container = new Container();
            container.Elements.Add(new Element());
            container.Elements.Add(new Element());
            var sub_container = new Container();
            sub_container.Elements.Add(new Element());
            container.Elements.Add(sub_container);
            return container;
        }
    }
    public interface IElement
    {
         string Title { get; }
    }
    public class Container : IElement
    {
        public string Title
        {
            get { return "Container"; }
        }
        private ObservableCollection<IElement> elements;
        public ObservableCollection<IElement> Elements
        {
            get
            {
                if (elements == null)
                {
                    elements = new ObservableCollection<IElement>();
                }
                return elements;
            }
        }
    }
    public class Element : IElement
    {
        public string Title
        {
            get { return "Element"; }
        }
    }
