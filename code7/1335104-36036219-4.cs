    public class YourViewModel : MvxViewModel
	{
		public ObservableCollection<SVModel> Coordinates => _coordinatesService.Coordinates;
		private readonly ICoordinatesService _coordinatesService;
		public YourViewModel(ICoordinatesService coordinatesService)
		{
			_coordinatesService = coordinatesService;
		}
		public void SaveSomeCoordinates()
		{
			Coordinates.Add(new SVModel());
		}
		public void RemoveSomeCoordinates()
		{
			Coordinates.RemoveAt(1);
		}
		public void ResetCoordinates()
		{
			_coordinatesService.Coordinates = new ObservableCollection<SVModel>();
		}
	}
