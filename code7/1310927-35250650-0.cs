    public partial class Window1 : Window
    {
       public ViewModel vm = new ViewModel();
       public Window1()
       {
        InitializeComponent();
        this.DataContext = vm;
        cmbChessTitles.ItemsSource = vm.Titles;
        vm.ChosenTitle = ChessTitles.WorldChampion;
        cmbChessTitles.SelectedItem = vm.ChosenTitle;
       }
    }
    public class ViewModel:INotifyPropertyChanged
    {
        public Array Titles
        {
            get { return Enum.GetValues(typeof(ChessTitles)); }
        }
    
        private ChessTitles _chosenTitle;
        public ChessTitles ChosenTitle
        {
            get{ return _chosenTitle ;}
            set { _chosenTitle = value; OnPropertyChanged("ChosenTitle"); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            if(PropertyChanged !=null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    
    public enum ChessTitles
    {
        WorldChampion,
        GrandMaster,
        FideMaster,
        InternationalMaster
    }
