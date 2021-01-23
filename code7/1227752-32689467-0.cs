     #region ParentItem
        public class BaseHeaderFooterItem<T>
            where T:class 
        {
            public string Title { get; set; }
            public string EnTitle { get; set; }
            public HyperLink Link { get; set; }
            public int Level { get; set; }
            public List<T> Descendants { get; set; }
        }
        #endregion
    
        #region HeaderFooter
        public class HeaderFooter : BaseHeaderFooterItem<Category>
        {
        }
        #endregion
    
        #region HeaderFooter
        public class Category : BaseHeaderFooterItem<Show>
        {
        }
        #endregion
    
        #region Header
        public class Show : HeaderFooter
        {
            public string ImagePath { get; set; }
            public string MobileLink { get; set; }
            public string MobileLinkTarget { get; set; }
        }
        #endregion
    
        #region TvGuid
        public class TvGuid : Show
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public int IsActive { get; set; }
            public int NoProgram { get; set; }
        }
        #endregion
