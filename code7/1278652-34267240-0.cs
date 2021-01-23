    public class AlphaKeypad
    {
        private Func<String, DataTable> _SearchMethod;
        public void SetSearchMethod(Func<String, DataTable> searchMethod)
        {
            _SearchMethod = searchMethod;
        }
        private void OnStartSearching()
        {
            var enteredSearch = GetKeywordsEnteredByUser();
            var dataTable = _SearchMethod(enteredSearch);
            Visualize(dataTable);
        }
    }
