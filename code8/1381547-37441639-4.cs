    public static class ViewDataExtensions
    {
        public static void Add(this ViewDataDictionary viewData, ViewDataType viewDataType, object value)
        {
            viewData.Add(viewDataType.ToString(), value);
        }
        public static TResult Get<TResult>(this ViewDataDictionary viewData, ViewDataType viewDataType)
            where TResult : class
        {
            var result = viewData[viewData.ToString()] as TResult;
            return result;
        }
    }
