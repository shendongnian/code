    namespace MySite.Models
    {
        [SitecoreType(AutoMap = true)]
        public class Folder<T> : GlassBase
        {
            [SitecoreChildren]
            public virtual IEnumerable<T> Children { get; set; }
        }
    }
