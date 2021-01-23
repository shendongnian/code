    public interface ISortable
    {
        public bool IsValidContext(object record, SortType type);
    }
    public class SortAlpha : ISortable
    {
        public bool IsValidContext(object record, SortType type)
        {
            return type == SortType.Ascend ? true : false; // example
        }
    }
    public class SortBeta : ISortable
    {
        public bool IsValidContext(object record, SortType type)
        {
            return type == SortType.Descend && record is HtmlDocument; // example
        }
    }
