     public class ViewModel : INotiFyPropertyChanged
    {
        private string _LabelContent;
        public string LabelContent
        {
            get { return _LabelContent; }
            set
            {
                _LabelContent= value;
                RaisePropertyChangedEvent("LabelContent");
            }
            }
       }
     //setting datacontext is crucial in MVVM
     public partial class MainWindow : Window
    {
        public ViewModel vm;
        public MainWindow ()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
     }
