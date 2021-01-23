    public class IReportRelation<TLocal, TForeign>
    {
        public TableMapper<TLocal> localMapper { get; set; }
    
        public Func<string, string> localProperty { get; set; }
    
        public Func<string, string> foreignProperty { get; set; }
    
        public TableMapper<TForeign> foreignMapper { get; set; }
    }
