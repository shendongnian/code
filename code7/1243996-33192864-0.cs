	public class SampleViewModel
	{
		public int SelectedYear { get; set; }
		public IEnumerable<int> SelectedMonths { get; set; }
		public IEnumerable<SelectListItem> Years { get; set; }
		public IEnumerable<SelectListItem> Months { get; set; }
	}
