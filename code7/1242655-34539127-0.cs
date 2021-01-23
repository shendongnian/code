    public class InventoryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Car> Cars { get; private set; }
    }
    <ComboBox ItemsSource="{Binding Path=Cars, Mode=OneWay}" ... />
