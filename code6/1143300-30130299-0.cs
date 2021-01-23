    <StackPanel>
        <ItemsControl x:Name="itms">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition/>
                            <RowDefinition/>
                            <RowDefinition/>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                            <ColumnDefinition/>
                        </Grid.ColumnDefinitions>
                        <TextBox Width="50" Text="{Binding Text1}" Grid.Row="0" Grid.Column="0"/>
                        <CheckBox IsChecked="{Binding Check1}" Content="Check1" Grid.Row="0" Grid.Column="1"/>
                        <TextBox Width="50" Text="{Binding Text2}" Grid.Row="1" Grid.Column="0"/>
                        <CheckBox IsChecked="{Binding Check2}" Content="Check2" Grid.Row="1" Grid.Column="1"/>
                        <TextBox Width="50" Text="{Binding Text3}" Grid.Row="2" Grid.Column="0"/>
                        <CheckBox IsChecked="{Binding Check3}" Content="Check3" Grid.Row="2" Grid.Column="1"/>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
        <Button Click="Button_Click" Content="Add Items"></Button>
    </StackPanel>
    public partial class Window2 : Window
    {
        ObservableCollection<MyClass> lst = new ObservableCollection<MyClass>();
        public Window2()
        {
            InitializeComponent();
            itms.ItemsSource = lst;
        }
        int i = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            i++;
            lst.Add(new MyClass() { Text1 = i.ToString(), Text2 =i.ToString()+1,Text3=i.ToString()+2,Check1=true,Check2=true,Check3=false});
        }
    }
    class MyClass
    {
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public bool Check1 { get; set; }
        public bool Check2 { get; set; }
        public bool Check3 { get; set; }
    }
