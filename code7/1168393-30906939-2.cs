    public class A
    {
        public virtual BView BView { get; set; }
    }
    public class BView
    {
        public virtual string ColumnY { get; set; }
    }
    public AMap()
    {
        References(x => x.BView)
    }
    public BMap()
    {
        Table("viewName");
    }
