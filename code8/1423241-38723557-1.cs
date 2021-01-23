    <Grid>
        <Grid.Resources>
            <local:StatusConverter x:Key="StatusConverter"></local:StatusConverter>
        </Grid.Resources>
        <DataGrid x:Name="DataGrid" AutoGenerateColumns="False" CanUserAddRows="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"></DataGridTextColumn>
                <DataGridTemplateColumn Header="Fungsi" Width="150" IsReadOnly="True" >
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Name="btn1" Content="Success" Background="Green"
                                        Visibility="{Binding Status,Converter={StaticResource StatusConverter},ConverterParameter=a}"></Button>
                                <Button Name="btn2" Content="InProg" Background="Yellow"
                                        Visibility="{Binding Status,Converter={StaticResource StatusConverter},ConverterParameter=b}"></Button>
                                <Button Name="btn3" Content="Failed" Background="Red"
                                        Visibility="{Binding Status,Converter={StaticResource StatusConverter},ConverterParameter=c}"></Button>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            List<MyClass> lst = new List<MyClass>();
            for (int i = 0; i < 10; i++)
            {
                MyClass obj = new MyClass();
                obj.Name = "Name" + i;
                if (i == 1)
                {
                    obj.Status=StatusEnum.Success;
                }
                else if (i == 2)
                {
                    obj.Status = StatusEnum.Failed;
                }
                else
                {
                    obj.Status = StatusEnum.InProgress;
                }
                lst.Add(obj);
            }
            DataGrid.ItemsSource = lst;
        }
    }
  
    class StatusConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                StatusEnum status = (StatusEnum)value;
                string param = parameter as string;
                if ((status == StatusEnum.Success && param == "a")|| (status == StatusEnum.InProgress && param == "b")|| (status == StatusEnum.Failed && param == "c"))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    class MyClass
    {
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
    }
    enum StatusEnum
    {
        Success,
        Failed,
        InProgress
    }
