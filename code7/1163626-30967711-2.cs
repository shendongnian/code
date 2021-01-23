	public class SearchBoxViewModel
	{
		[Required]
		[Display(Name = "Search")]
		public string SearchPhrase { get; set; }
		
		[Display(Name = "Search")]
		public string q
		{
			get { return SearchPhrase; }
			set { SearchPhrase = value; }
		}
	}
