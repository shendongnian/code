        public class FreezableProxyClass : Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new FreezableProxyClass();
        }
        public static readonly DependencyProperty ProxiedDataContextProperty = DependencyProperty.Register(
            "ProxiedDataContext", typeof(object), typeof(FreezableProxyClass), new PropertyMetadata(default(object)));
        public object ProxiedDataContext
        {
            get { return (object)GetValue(ProxiedDataContextProperty); }
            set { SetValue(ProxiedDataContextProperty, value); }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var selectedSubModel = new SubModel { Description = "SubModel5" };
            var model1 = new Model
            {
                Name = "Model1",
                Items = new ObservableCollection<SubModel>
                {
                    new SubModel { Description = "SubModel1" },
                    new SubModel { Description = "SubModel2" },
                    new SubModel { Description = "SubModel3" }
                }
            };
            var model2 = new Model
            {
                Name = "Model2",
                SelectedItem = selectedSubModel,
                Items = new ObservableCollection<SubModel>
                {
                    new SubModel { Description = "SubModel4" },
                    selectedSubModel,
                    new SubModel { Description = "SubModel6" }
                }
            };
            var model3 = new Model
            {
                Name = "Model3",
                Items = new ObservableCollection<SubModel>
                {
                    new SubModel { Description = "SubModel7" },
                    new SubModel { Description = "SubModel8" },
                    new SubModel { Description = "SubModel9" }
                }
            };
            _itemsControl.Items.Add(model1);
            _itemsControl.Items.Add(model2);
            _itemsControl.Items.Add(model3);
        }
    }
    public class Model:BaseObservableObject
    {
        private string _name;
        private SubModel _selectedItem;
        private ObservableCollection<SubModel> _items;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public SubModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SubModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    }
    public class SubModel:BaseObservableObject
    {
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
