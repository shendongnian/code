    public interface ICoordinatesService
	{
		ObservableCollection<SVModel> Coordinates { get; set; }
	}
	public class CoordinatesService : ICoordinatesService
	{
		public ObservableCollection<SVModel> Coordinates { get; set; }
	}
