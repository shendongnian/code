    <DataGrid CanUserAddRows="True" AutoGenerateColumns="False" ItemsSource="{Binding SimpleCollection}">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding A}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding B}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding C}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
        public class SimpleClass
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
        }
    private ObservableCollection<SimpleClass> _simpleCollection;
    public ObservableCollection<SimpleClass> SimpleCollection
    {
    
    get { return _simpleCollection ?? (_simpleCollection = new ObservableCollection<SimpleClass>());     }
    
    set { _simpleCollection = value; }
    }
