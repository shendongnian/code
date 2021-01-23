	public class CarList : ListView
	{
		public CarList()
			: base()
		{
			foreach (var car in CarRecords.LoadCars())
			{
				var listViewItem = new ListViewItem(car);
				car.OnDelete = this.DeleteCarFromList;
				
				this.Items.Add(listViewItem);
			}
		}
	
		private void DeleteCarFromList(Car deletedCar)
		{
			this.Items.Remove(deletedCar);
		}
	}
