    <Window.Resources>
        <DataTemplate DataType="{x:Type local:PersonVm}">
            <local:Person/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type local:DeptVm}">
            <local:Department/>
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <TabControl ItemsSource="{Binding TabCollection}" SelectedIndex="0">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding TabName}"/>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <ContentControl  Content="{Binding }"/>
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
    </Grid>
    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new TabViewModel();
            }
        }
    
        public class TabViewModel
        {
            public ObservableCollection<object> TabCollection { get; set; }
    
            public TabViewModel()
            {
                TabCollection = new ObservableCollection<object>();
                PopulateTabCollection();
            }
    
            private void PopulateTabCollection()
            {
                TabCollection.Add(new PersonVm()
                {
                    PersonName = "FirstUserControl",
                    Address = "Address",
                    TabName = "Person Tab"
                });
    
                TabCollection.Add(new DeptVm()
                {
                    DeptName = "SecondUserControl",
                    TabName = "DeptTab"
                });
            }
        }
    
        public class PersonVm
        {
            public string PersonName { get; set; }
            public string Address { get; set; }
            public string TabName { get; set; }
            
        }
    
        public class DeptVm
        {
            public string DeptName { get; set; }
            public string TabName { get; set; }
        }
 
      
