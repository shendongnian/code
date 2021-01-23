    public class SearchFieldAttribute : Attribute
    {
        public SearchFieldAttribute(string searchField)
        {
            SearchField = searchField;
        }
        public string SearchField { get; private set; }
    }
