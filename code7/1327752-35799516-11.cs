	public class ApartmentRepository
	{
		private readonly List<Apartment> _apartmentData;
		
		public ApartmentRepository(List<Apartment> apartmentData)
		{
			_apartmentData = apartmentData;
		}
	
		public Apartment Search(int price, int numberOfRooms, string type)
		{
			return _apartmentData.FirstOrDefault(a => a.Price == price 
												   && a.NumberOfRooms == numberOfRooms
												   && a.Type == type);
		}
	}
