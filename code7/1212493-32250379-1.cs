     public partial class MainWindow : Window
        {
            public ViewModel model = new ViewModel();
            public MainWindow()
            {
                InitializeComponent();
                DataContext = model;
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                model.Opts.Prop1 = typeof(DataModel).GetFields()
                    .Where(a => a.Name == ComboBox1.SelectedItem.ToString()).FirstOrDefault();
                model.Opts.Prop2 = typeof(DataModel).GetFields()
                    .Where(a => a.Name == ComboBox2.SelectedItem.ToString()).FirstOrDefault();
                DataContext = null;
                DataContext = model;
            }
        }
    
        public class ViewModel
        {
            public DisplayOptions Opts = new DisplayOptions();
    
            public List<String> DataModelProperties { get; set; }
    
            public List<DataModel> DataModelList { get; set; }
    
            public ViewModel()
            {
                var properties = typeof(DataModel).GetFields()
                  .Where(a => a.CustomAttributes.Any(b => b.AttributeType == typeof(SwitchableAttr)));
    
                //Initialising options before creating DataModel instances
                DataModelProperties = properties.Select(s => s.Name).ToList();
                Opts.Prop1 = properties.ElementAt(0);
                Opts.Prop2 = properties.ElementAt(1);
    
    
                DataModelList = new List<DataModel>();
                DataModelList.Add(new DataModel() { Name = "Name1", Code = "Code1", Desc = "Desc1", options = Opts });
                DataModelList.Add(new DataModel() { Name = "Name2", Code = "Code2", Desc = "Desc2", options = Opts });
                DataModelList.Add(new DataModel() { Name = "Name3", Code = "Code3", Desc = "Desc3", options = Opts });
            }
        }
    
        public class DisplayOptions
        {
            public FieldInfo Prop1;
            public FieldInfo Prop2;
        }
    
        public class DataModel
        {
            public DisplayOptions options;
            [SwitchableAttr]
            public string Name;
            [SwitchableAttr]
            public string Desc;
            [SwitchableAttr]
            public string Code;
    
            public string DisplayProperty1 { get { return (string)options.Prop1.GetValue(this); } set { } }
            public string DisplayProperty2 { get { return (string)options.Prop2.GetValue(this); } set { } }
        }
    
        public class SwitchableAttr : Attribute { }
