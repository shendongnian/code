	public class CproductsColl : ObservableCollection<Cproducts>
	{
		public User AddAvailability(Availability av)
		{
			base.Add(av);
			return av;
		}
	}		
