        [Export ("updateSearchResultsForSearchController:")]
		public virtual void UpdateSearchResultsForSearchController (UISearchController searchController)
		{
			var tableController = (UITableViewController)searchController.SearchResultsController;
			var resultsSource = (ResultsTableSource)tableController.TableView.Source;
			resultsSource.SearchedItems = PerformSearch (searchController.SearchBar.Text);
			tableController.TableView.ReloadData ();
		}
        static List<string> PerformSearch (string searchString)
		{
			// Return a list of elements that correspond to the search or
            // parse an existing list.
		}
