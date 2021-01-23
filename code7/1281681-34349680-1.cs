     <Window.Resources>
        <Style TargetType="{x:Type DataGridCell}" x:Key="MyCellStyle">
            <Style.Triggers>
                <DataTrigger Binding="{Binding Id}" Value="2">
                    <Setter Property="Background" Value="LightCoral"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid Margin="10">  
        <DataGrid Name="dgUsers" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding Id}" CellStyle="{StaticResource ResourceKey=MyCellStyle }" />
                <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
                <DataGridTextColumn Header="Birthday" Binding="{Binding Birthday}" />
            </DataGrid.Columns>
            <DataGrid.RowDetailsTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Details}" Margin="10" />
                </DataTemplate>
            </DataGrid.RowDetailsTemplate>
          
        </DataGrid>
    </Grid>
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        
    }
        public MainWindow()
        {
            InitializeComponent();
            List<User> users = new List<User>();
            users.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            users.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) });
            users.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });
            dgUsers.ItemsSource = users;
        }
