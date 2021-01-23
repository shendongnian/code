<!-- -->
    public class ReportRelation<TLocal, TForeign> : IReportRelation<TLocal, TForeign>
    {
        ITableMapper IReportRelation.LocalMapper { get { return LocalMapper; } }
        ITableMapper IReportRelation.ForeignMapper { get { return ForeignMapper; } }
        public TableMapper<TLocal> LocalMapper { get; set; }
        public TableMapper<TForeign> ForeignMapper { get; set; }
        public IReportColumn ForeignColumn { get; set; }
        public IReportColumn LocalColumn { get; set; }
    }
