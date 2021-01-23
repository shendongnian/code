    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Data> _datas = new ObservableCollection<Data>()
        {
            new Data()
            {
                Prop1 = "val1",
                Prop2 = "val2",
                GroupeBrush=new SolidColorBrush(Colors.Blue)
            }, new Data()
            {
                Prop1 = "val1",
                Prop2 = "val2",
                GroupeBrush=new SolidColorBrush(Colors.Blue)
            }, new Data()
            {
                Prop1 = "val1",
                Prop2 = "val3",
                GroupeBrush=new SolidColorBrush(Colors.Blue)
            }, new Data()
            {
                Prop1 = "val2",
                Prop2 = "val4",
                GroupeBrush=new SolidColorBrush(Colors.Green)
            }, new Data()
            {   
                Prop1 = "val3",
                Prop2 = "val5",
                GroupeBrush=new SolidColorBrush(Colors.Red)
            },
        };
        public ObservableCollection<Data> Datas
        {
            get
            {
                return _datas;
            }
            set
            {
                if (_datas == value)
                {
                    return;
                }
                _datas = value;                
            }
        }
        public MainPage()
        {
            this.DataContext = this;
            InitializeComponent();
            DataCollection.Source = GetAllGrouped();
        }
        public IEnumerable<IGrouping<string, Data>> GetAllGrouped()
        {
            return Datas.GroupBy(x => x.Prop1);
        }      
    }
    public class Data
    {
        public String Prop1 { get; set; }
        public String Prop2 { get; set; }
        public SolidColorBrush GroupeBrush { get; set; } //the groupe background color
    }
 
