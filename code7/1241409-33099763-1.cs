    public partial class MainWindow : Window
    {
        CustomAttributEditorPerson temp = new CustomAttributEditorPerson();
        public MainWindow()
        {
            InitializeComponent();
            temp.Date = new DateTime(2020, 7, 7, 0, 1, 2);
            _propertyGrid.SelectedObject = temp;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            temp.Date = new DateTime(2030, 8, 7, 0, 1, 2);
            _propertyGrid.Update();
        }
    }
    public class CustomAttributEditorPerson : INotifyPropertyChanged
    {
        private DateTime FDate;
        [Category("Information")]
        [DisplayName("Date")]
        //This custom editor is a Class that implements the ITypeEditor interface
        [RefreshProperties(RefreshProperties.All)]
        public DateTime Date
        {
            get
            {
                return this.FDate;
            }
            set
            {
                this.FDate = value;
                NotifyPropertyChanged("Date");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
