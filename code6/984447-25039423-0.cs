	public class FilterSample : INotifyPropertyChanged
	{
		public ObservableCollection<Car> Cars { get; private set; }
		public ObservableCollection<Motorcycle> Motorcycles { get; private set; }
		public ObservableCollection<IVehicle> AllVehicles { get; private set; }
		public FilterSample()
		{
			Cars = new ObservableCollection<Car>();
			Motorcycles = new ObservableCollection<Motorcycle>();
			AllVehicles = new ObservableCollection<IVehicle>();
			CollectionViewSource.GetDefaultView(AllVehicles).Filter = AllVehicleFilter;
		}
		private bool AllVehicleFilter(object o)
		{
			IVehicle vehicle = o as IVehicle;
			vehicle = o as IVehicle;
			if (vehicle == null)
				return false;
			
			Car car = o as Car;
			Motorcycle motorcycle = o as Motorcycle;
			if (car != null)
			{
				switch (CurrentRegion)
				{
					 // custom handling 
				}
			}
            // etc
		}
		public string CurrentRegion { get; set; }
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	public class Car : IVehicle
	{
		public int Tires { get { return 4; } }
	}
	public class Motorcycle : IVehicle
	{
		public int Tires { get { return 2; } }
	}
	public interface IVehicle
	{
		int Tires { get; }
	}
