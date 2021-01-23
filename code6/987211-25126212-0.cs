    if (string.IsNullOrEmpty(scope) && !string.IsNullOrEmpty(query))
            {
                _totalResults = SearchHelper.ExecuteQuerySearch(query, Model.Divisions).ToList();
            }
            else if (!string.IsNullOrEmpty(query))
            {
                _totalResults = SearchHelper.ExecuteQuerySearch(query).ToList();
            }
            else
            {
                _totalResults = new List<SearchItem>();
            }
