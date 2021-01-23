    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class OrderViewModel : ViewModelBase
    {
        public ObservableCollection<string> ComboBoxOptions { get; set; }
        private string orderId;
        private string instrumentId;
        private string selectedComboOption;
        public OrderViewModel()
        {
            ComboBoxOptions = new ObservableCollection<string>
            {
                "Option1",
                "Option2",
                "Option3",
            };            
        }
        public string OrderId
        {
            get { return orderId; }
            set
            {
                orderId = value;
                OnPropertyChanged();
            }
        }
        public string InstrumentId
        {
            get { return instrumentId; }
            set
            {
                instrumentId = value;
                OnPropertyChanged();
            }
        }
        public string SelectedComboOption
        {
            get { return selectedComboOption; }
            set
            {
                selectedComboOption = value;
                OnPropertyChanged();
            }
        }
    }
    [Export]
    public class MainViewModel : ViewModelBase
    {
        private OrderViewModel selectedOrder;
        public ObservableCollection<OrderViewModel> Orders { get; set; }        
        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>
            {
                new OrderViewModel {OrderId = "Order1", InstrumentId = "Instrument1"},
                new OrderViewModel {OrderId = "Order2", InstrumentId = "Instrument2"},
                new OrderViewModel {OrderId = "Order2", InstrumentId = "Instrument3"}
            };
        }
        public OrderViewModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged();
            }
        }
    }
    <Window x:Class="WpfTestProj.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
        xmlns:local="clr-namespace:WpfTestProj"
        mc:Ignorable="d" 
        d:DataContext="{d:DesignInstance Type=local:MainViewModel, IsDesignTimeCreatable=False}"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ListView ItemsSource="{Binding Orders}" SelectedItem="{Binding SelectedOrder}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <TextBox Text="{Binding OrderId}" />
                        <TextBox Text="{Binding InstrumentId}" />
                        <ComboBox ItemsSource="{Binding ComboBoxOptions}"                                  
                                  SelectedItem="{Binding SelectedComboOption}"/>
                    </StackPanel>                    
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
