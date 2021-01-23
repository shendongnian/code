    <Grid>
        <Grid.Resources>
            <converters:AmountFromQuantityAndRateConverter x:Key="amountFromQuantityAndRateConverter" />
        </Grid.Resources>
            
        <DataGrid ItemsSource="{Binding OpeningBalances}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Quantity" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Quantity, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
        
                <DataGridTemplateColumn Header="Rate" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Rate, UpdateSourceTrigger=PropertyChanged}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
        
                <DataGridTemplateColumn Header="Amount" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock>
                                <TextBlock.Text>
                                    <MultiBinding Converter="{StaticResource amountFromQuantityAndRateConverter}">
                                        <Binding Path="Quantity" UpdateSourceTrigger="PropertyChanged" />
                                        <Binding Path="Rate" UpdateSourceTrigger="PropertyChanged"  />
                                    </MultiBinding>
                                </TextBlock.Text>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid> 
  
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            OpeningBalances = new ObservableCollection<ItemOpeningBalanceRow>(new [] { new ItemOpeningBalanceRow()});
            DataContext = this;
        }
    
        private ObservableCollection<ItemOpeningBalanceRow> _openingBalances;
        public ObservableCollection<ItemOpeningBalanceRow> OpeningBalances
        {
            get
            {
                return _openingBalances;
            }
            set
            {
                _openingBalances = value;
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class ItemOpeningBalanceRow : INotifyPropertyChanged
    {
        private double _quantity;
        private double _rate;
    
        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value;  OnPropertyChanged(); }
        }
        public double Rate {
            get { return _rate; }
            set { _rate = value; OnPropertyChanged(); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class AmountFromQuantityAndRateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int _quantity = 0;
            int _rate = 0;
    
            if (int.TryParse(values[0].ToString(), out _quantity) && int.TryParse(values[1].ToString(), out _rate))
            {
                return (_quantity * _rate).ToString();
            }
    
            return 0;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
