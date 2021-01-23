    <TextBox Name="IDTextbox" AcceptsReturn="True" TextWrapping="Wrap" SpellCheck.IsEnabled="True" Language="en-US" />
    <TextBox Name="titleText" AcceptsReturn="True" TextWrapping="Wrap" SpellCheck.IsEnabled="True" Language="en-US" />
    <TextBox Name="QuantityTextbox" AcceptsReturn="True" TextWrapping="Wrap" SpellCheck.IsEnabled="True" Language="en-US" />
    <TextBox Name="PriceTextbox" AcceptsReturn="True" TextWrapping="Wrap" SpellCheck.IsEnabled="True" Language="en-US" />
    <TextBox Name="BrandTextbox" AcceptsReturn="True" TextWrapping="Wrap" SpellCheck.IsEnabled="True" Language="en-US" />
    <Button Content="Add new row" HorizontalAlignment="Left" Margin="0,10,0,0" VerticalAlignment="Top" Width="75" Click="Button_Click"/>
    
    <DataGrid AutoGenerateColumns="False" Name="DataGrid1" CanUserAddRows="True" ItemsSource="{Binding TestBinding}" Margin="0,50,0,0" >
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Brand" IsReadOnly="True" Binding="{Binding Path=Brand}" Width="50"></DataGridTextColumn>
                    <DataGridTextColumn Header="Title" IsReadOnly="True"  Binding="{Binding Path=Title}" Width="130"></DataGridTextColumn>
                    <DataGridTextColumn Header="Quantity" IsReadOnly="True"  Binding="{Binding Path=Quantity}" Width="130"></DataGridTextColumn>
                    <DataGridTextColumn Header="Price" IsReadOnly="True" Binding="{Binding Path=Price}" Width="130"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = new Test { Brand= BrandTextbox.Text, Title= titleText.Text,
                    Quantity = QuantityTextbox.Text, Price = PriceTextbox.Text };
    
            DataGridTest.Items.Add(data);
        }
    }
    public class Test
    {
        public string Brand { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
