     <DataGrid x:Name="dgr" AutoGenerateColumns="False" ItemsSource="{Binding LoadDataBinding}">           
            <DataGrid.Columns>                
                <DataGridTextColumn Binding="{Binding Path=PrecioGram, Mode=TwoWay}" Header="Precio por Gramo" Width="190" IsReadOnly="True">
                    <DataGridTextColumn.HeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="HorizontalContentAlignment" Value="Center" />
                            <Setter Property="FontSize" Value="14" />
                        </Style>
                    </DataGridTextColumn.HeaderStyle>
                </DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding Path=Gramos, Mode=TwoWay}" Header="Gramos" Width="190" IsReadOnly="False">
                    <DataGridTextColumn.HeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="HorizontalContentAlignment" Value="Center" />
                            <Setter Property="FontSize" Value="14" />
                        </Style>
                    </DataGridTextColumn.HeaderStyle>
                </DataGridTextColumn>
                <DataGridTextColumn Header="Total" Width="100" Binding="{Binding Total}">
                    <DataGridTextColumn.HeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="HorizontalContentAlignment" Value="Center" />
                            <Setter Property="FontSize" Value="14" />
                        </Style>
                    </DataGridTextColumn.HeaderStyle>
                    
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
     public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
       
    }
    public class MainViewModel
    {
        private ObservableCollection<Entity_Class> myVar = new ObservableCollection<Entity_Class>();
        public ObservableCollection<Entity_Class> LoadDataBinding
        {
            get { return myVar; }
            set { myVar = value; }
        }
                
        public MainViewModel()
        {
            for (int i = 1; i < 10; i++)
            {
                LoadDataBinding.Add(new Entity_Class() { PrecioGram=i});
            }
        }
    }   
    public class Entity_Class : INotifyPropertyChanged
    {
        private int _preciogram;
        public int PrecioGram
        {
            get { return _preciogram; }
            set { _preciogram = value; NotifyPropertyChanged("PrecioGram"); }
        }
        private int _gramos;
        public int Gramos
        {
            get { return _gramos; }
            set
            { 
                _gramos = value; NotifyPropertyChanged("gramos");
                Total = _preciogram * _gramos;
            }
        }
        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; NotifyPropertyChanged("Total"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
