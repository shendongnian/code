    public class ViewModel : DependencyObject
    {
        public ObservableCollection<Vehicle> vehicles { get; set; }
        public ICommand ChangeCommand { get; set; }
        public Vehicle VehicleSelected
        {
            get { return (Vehicle)GetValue(VehicleSelectedProperty); }
            set { SetValue(VehicleSelectedProperty, value); }
        }
        // Using a DependencyProperty as the backing store for VehicleSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VehicleSelectedProperty =
            DependencyProperty.Register("VehicleSelected", typeof(Vehicle), typeof(ViewModel), new PropertyMetadata(null));
        public ViewModel()
        {
            vehicles = new ObservableCollection<Vehicle>();
            Vehicle veh1 = new Vehicle() { Name = "V1" };
            Vehicle veh2 = new Vehicle() { Name = "V2" };
            Vehicle veh3 = new Vehicle() { Name = "V3" };
            Vehicle veh4 = new Vehicle() { Name = "V4" };
            vehicles.Add(veh1);
            vehicles.Add(veh2);
            vehicles.Add(veh3);
            vehicles.Add(veh4);
            ChangeCommand = new ChangeCommand(this);
        }
    }
