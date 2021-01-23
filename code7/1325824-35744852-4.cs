    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        private string StringHeaderTemplate = @"<DataTemplate>
       <Grid Background=""Transparent"">
            <i:Interaction.Triggers>
             <i:EventTrigger EventName=""MouseLeftButtonDown"">             
               <si:CallMethodAction MethodName = ""Grid_MouseLeftButtonDown"" TargetObject=""{Binding RelativeSource={RelativeSource AncestorType=Window}}""/>
             </i:EventTrigger>
            </i:Interaction.Triggers>
            <Grid.RowDefinitions>
              <RowDefinition/>
              <RowDefinition/>
              <RowDefinition/>
          </Grid.RowDefinitions>
          <Button Content=""Hello""/>
          <TextBlock Grid.Row=""1"" HorizontalAlignment= ""Center"" Text = ""Grid_MouseLeftButtonDown"" />
          <CheckBox Grid.Row= ""2"" HorizontalAlignment= ""Center"" IsChecked= ""True"" />
       </Grid >    
    </DataTemplate>";
        private string DateTimeWithCommandHeaderTemplate = @"<DataTemplate>
       <Grid Background=""Transparent"">
            <i:Interaction.Triggers>
             <i:EventTrigger EventName=""MouseLeftButtonDown"">             
               <i:InvokeCommandAction Command = ""{Binding DataContext.CallSortingCommand, RelativeSource={RelativeSource AncestorType=Window}}""/>
             </i:EventTrigger>
            </i:Interaction.Triggers>
            <Grid.RowDefinitions>
              <RowDefinition/>
              <RowDefinition/>
              <RowDefinition/>
          </Grid.RowDefinitions>
          <Button Content=""Hello""/>
          <TextBlock Grid.Row=""1"" HorizontalAlignment= ""Center"" Text = ""CallSortingCommand"" />
          <CheckBox Grid.Row= ""2"" HorizontalAlignment= ""Center"" IsChecked= ""True"" />
       </Grid >    
    </DataTemplate>";
        private string TimeCellTemplate = @"<DataTemplate>
          <TextBlock HorizontalAlignment= ""Center"" Text = ""{Binding Time}"" />
    </DataTemplate>";
        private string DescCellTemplate = @"<DataTemplate>
          <TextBlock HorizontalAlignment= ""Center"" Text = ""{Binding Desc}"" />
    </DataTemplate>";
        public void Grid_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
        private DataTemplate GetDatatemplate(string fromstring)
        {
            ParserContext context = new ParserContext();
            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("i", "clr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity");
            context.XmlnsDictionary.Add("si", "clr-namespace:Microsoft.Expression.Interactivity.Core;assembly=Microsoft.Expression.Interactions");
            return (DataTemplate)XamlReader.Parse(fromstring, context);
        }
        private void dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataTemplate dtHeader = null;
            string dtString = string.Empty;
            string dtHeaderString = string.Empty;
            DataGridTemplateColumn column = null;
            switch (Type.GetTypeCode(e.PropertyType))
            {
                case TypeCode.String:
                    {
                        column = new DataGridTemplateColumn()
                        {
                            CellTemplate = GetDatatemplate(DescCellTemplate),
                            HeaderTemplate = GetDatatemplate(StringHeaderTemplate),
                        };
                    }
                    
                    break;
                case TypeCode.DateTime:
                    {
                        column = new DataGridTemplateColumn()
                        {
                            CellTemplate = GetDatatemplate(TimeCellTemplate),
                            HeaderTemplate = GetDatatemplate(DateTimeWithCommandHeaderTemplate),
                        };
                    }
                    
                    break;
            }
            if (column != null)
            {
                e.Column = column;
            }
        }
    }
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                _collection.Add(new MyObject() { Time = DateTime.Now.AddSeconds(i), Desc = i.ToString() });
            }
            CallSortingCommand = new DelegateCommand(OnCallSortingCommand, (o) => true);
        }
        private void OnCallSortingCommand(object obj)
        {
            MessageBox.Show("From OnCallSortingCommand");
        }
        public ICommand CallSortingCommand { get; set; }
        private ObservableCollection<MyObject> _collection = new ObservableCollection<MyObject>();
        public ObservableCollection<MyObject> Items
        {
            get
            {
                return _collection;
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }     
    }
    public class MyObject
    {
        public DateTime Time { get; set; }
        public string Desc { get; set; }
    }
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
