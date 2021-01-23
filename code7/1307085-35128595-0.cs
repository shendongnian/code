    public class TabControlViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TabItemViewModel> Tabs {get;set;}
        public TabControlViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem { ... });
        }
    }
    public sealed class TabItemViewModel : INotifyPropertyChanged
    {
        public string Header { get; set; }
        public ObservableCollection<DataGridRowVM> DataGridItemsSource {get;set;}
        public TabControlViewModel()
        {
            DataGridItemsSource = new ObservableCollection<DataGridRowVM>();
            DataGridItemsSource .Add(new DataGridRowVM{ ... });
        }
    }
    public sealed class DataGridRowVM: INotifyPropertyChanged
    {
        public string PortName { get; set; }
        public string DriverName{ get; set; }
        .....
    }
    <TabControl ItemsSource="{Binding Tabs}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Header}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <DataTemplate>
            <DataGrid CanUserSortColumns="True" RowDetailsVisibilityMode="Visible" ItemsSource="{Binding DataGridItemsSource}>
            <!-- Your template goes here-->
            </DataGrid>
                
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
