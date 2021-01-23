    public struct SearchReplace<T>
    {
        public SearchReplace(string data, string searchValue, T replaceValue)
        {
            this.Data = data;
            this.SearchValue = searchValue;
            this.ReplaceValue = replaceValue;
        }
        string Data;
        string SearchValue;
        T ReplaceValue;
    }
