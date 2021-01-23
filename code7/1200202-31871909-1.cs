	public class YourVM {
		public YourVM() {
			int startYear = DateTime.Now.Year;
			DateTime currentDate = new DateTime(startYear, 1, 1);
			while(currentDate.Year == startYear) {
				_listOfDates.Add(currentDate);
				currentDate = currentDate.AddDays(1);
			}
		}
		
		private List<DateTime> _listOfDates = new List<DateTime>(365);
		public List<DateTime> ListOfDates { get { return _listOfDates; } }
	}
