    <ListBox x:Name="lbDocxFiles" HorizontalContentAlignment="Stretch"  >
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid >
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="90" />
                            <ColumnDefinition Width="70" />
                            <ColumnDefinition Width="50" />
                        </Grid.ColumnDefinitions>
                        <CheckBox x:Name="checkBox" Grid.Column="3" Content="Tets" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        <TextBox  x:Name="tbNodeID" IsReadOnly="False" AcceptsReturn="True" 
                                  IsEnabled="True" Focusable="True"  TextWrapping="Wrap" HorizontalAlignment="Right" 
                                  Height="25" Width="90" Text="" VerticalAlignment="Center" Grid.Column="1">
                            <TextBox.Style>
                                <Style TargetType="{x:Type TextBox}">
                                    <Style.Triggers>
                                        <Trigger Property="IsFocused" Value="True">                                            
                                            <Setter Property="IsReadOnly" Value="False" />
                                        </Trigger>
                                        <Trigger Property="IsFocused" Value="False">                                           
                                            <Setter Property="IsReadOnly" Value="True" />
                                        </Trigger>
                                    </Style.Triggers>
                                </Style>
                            </TextBox.Style>
                        </TextBox>
                        <Button Grid.Column="2" Width="70" Height="25" Content="UPLOAD" 
                                Background="#FF70ECD5" BorderThickness="0" Foreground="White" />
                        <TextBlock Grid.Column="0" Text="{Binding MyProperty}"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
      public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<MyModel> lst = new ObservableCollection<MyModel>();
            lst.Add(new MyModel() { MyProperty = "Hi" });
            lbDocxFiles.ItemsSource = lst;
        }
    }
    class MyModel
    {
        private string myVar;
        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
