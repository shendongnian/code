    public interface IReportRelation<TLocal, TForeign>
    {
        TableMapper<TLocal> LocalMapper { get; set; }
        TableMapper<TForeign> ForeignMapper { get; set; }
        IReportColumn ForeignColumn { get; set; }
        IReportColumn LocalColumn { get; set; }
    }
    public class ReportRelation<TLocal, TForeign> : IReportRelation<TLocal, TForeign>
    {
        public TableMapper<TLocal> LocalMapper { get; set; }
        public TableMapper<TForeign> ForeignMapper { get; set; }
    }
