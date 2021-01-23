         public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
			this.DataContext = this;
        }
        private Entity _entity;
        public Entity Entity
        {
            get
            {
                if(_entity == null)
                    _entity = new Entity();
                return _entity;
            }
        }
        public List<Entity> Entities
        {
            get { return CreateMyTree(); }
        }
        private List<Entity> CreateMyTree()
        {
            var list = new List<Entity>();
            var p1 = new Entity {Title = "Parent 1"};
            p1.Children.Add(new Entity{ Title = "Child 1"});
            p1.Children.Add(new Entity { Title = "Child 2" });
            var p2 = new Entity { Title = "Parent 2" };
            var c1 = new Entity { Title = "Child 1"};
            
            var g1 = new Entity {Title = "GrandChild 1"};
            c1.Children.Add(g1);
            var c2 = new Entity { Title = "Child 2" };
            p2.Children.Add(c1);
            p2.Children.Add(c2);
            list.Add(p1);
            list.Add(p2);
            return list;
        }
    }
    public class Entity : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        private List<Entity> _children;
        public List<Entity> Children
        {
            get
            {
                if(_children == null)
                    _children = new List<Entity>();
                return _children;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
