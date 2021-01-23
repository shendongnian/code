	public class MyViewModel : ViewModelBase
	{
		private DateTime _StartDate;
		public DateTime StartDate
		{
			get { return this._StartDate; }
			set
			{
				this._StartDate = value;
				RaisePropertyChanged(() => this.StartDate);
				ApplyFilter();
			}
		}
		private IList<DateTime> _FilteredDates;
		public IList<DateTime> FilteredDates
		{
			get { return this._FilteredDates; }
			set { this._FilteredDates = value; RaisePropertyChanged(() => this.FilteredDates); }
		}
		private void ApplyFilter()
		{
			this.FilteredDates = new ObservableCollection<DateTime>(
				Enumerable.Range(0, 14)
				.Select(i => this.StartDate.AddDays(i)));
		}
