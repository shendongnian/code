<!-- -->
    public interface IReportRelation
    {
        ITableMapper LocalMapper { get; }
        ITableMapper ForeignMapper { get; }
    
        IReportColumn ForeignColumn { get; set; }
        IReportColumn LocalColumn { get; set; }
    }
    public interface IReportRelation<TLocal, TForeign> : IReportRelation
    {
        new TableMapper<TLocal> LocalMapper { get; set; }
        new TableMapper<TForeign> ForeignMapper { get; set; }
    }
