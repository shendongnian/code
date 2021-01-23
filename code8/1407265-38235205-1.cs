<!-- -->
    public interface IReportRelation
    {
        ITableMapper LocalMapper { get; set; }
        ITableMapper ForeignMapper { get; set; }
    
        IReportColumn ForeignColumn { get; set; }
        IReportColumn LocalColumn { get; set; }
    }
    public interface IReportRelation<TLocal, TForeign> : IReportRelation
    {
        new TableMapper<TLocal> LocalMapper { get; set; }
        new TableMapper<TForeign> ForeignMapper { get; set; }
    }
