	public partial class SearchResults : Form
    {
        private List<string> passedResult;
        public SearchResults(List<string> results)
        {
	        passedResults = results; // Then use your list.
            InitializeComponent();
        }    
    }
