    abstract class Pagination<T>
    {
        public int _offset { get; set; }
        public int _total { get; set; }
        public string previous { get; set; }
        public string next { get; set; }
        public abstract List<T> items { get; set; }
        public int getItemCount()
        {
            return items != null ? items.Count() : 0;
        }
        /// <summary>
        /// Factory method to build the pagination object from Json string.
        /// </summary>
        public static TCurrent CreateFromJsonString<TCurrent>(string _json) where TCurrent: Pagination<T>
        {
            return JsonConvert.DeserializeObject<TCurrent>(_json);
        }
    }
