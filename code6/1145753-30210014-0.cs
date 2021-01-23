    public static class Extensions
    {
        public static RemarkItem GetRemarkItem(this XElement xDataItem)
        {
            return new RemarkItem
            {
                RemarkType = RemarkType.Type1,
                Description = "bla bla" // temp
            };
        }
        public static RemarkItem GetRemarkItem(this XElement xDataItem, RemarkType type)
        {
            return new RemarkItem
            {
                RemarkType = type,
                Description = "bla bla" // temp
            };
        }
    }
