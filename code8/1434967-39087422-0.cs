	struct DateRange {
		public DateTime StartDate, EndDate;
		public override string ToString() {
			return $"{StartDate} - {EndDate}";
		}
	};
	static void Main(string[] args) {
		var list1 = new List<DateRange>() {
			new DateRange() { StartDate = DateTime.Parse("1/1/2016 5AM"), EndDate = DateTime.Parse("1/1/2016 10PM") },
			new DateRange() { StartDate = DateTime.Parse("1/2/2016 4AM"), EndDate = DateTime.Parse("1/2/2016 8AM") }
		};
		var list2 = new List<DateRange>() {
			new DateRange() { StartDate = DateTime.Parse("1/1/2016 10AM"), EndDate = DateTime.Parse("1/1/2016 11AM")},
			new DateRange() { StartDate = DateTime.Parse("1/1/2016 4PM"), EndDate = DateTime.Parse("1/1/2016 5PM")},
			new DateRange() { StartDate = DateTime.Parse("1/2/2016 5AM"), EndDate = DateTime.Parse("1/2/2016 10PM")}
		};
		var overlapList = from outer in list1
							from inner in list2
							where outer.StartDate < inner.EndDate && inner.StartDate < outer.EndDate
							select new DateRange() {
								StartDate = new DateTime(Math.Max(outer.StartDate.Ticks, inner.StartDate.Ticks)),
								EndDate = new DateTime(Math.Min(outer.EndDate.Ticks, inner.EndDate.Ticks))
							};
	}
