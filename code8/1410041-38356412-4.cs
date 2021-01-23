    public class ReportRelationMapping : IReportRelationMapping
    {
        public string Name { get; set; }
        public SqlJoinStatement JoinType { get; set; }
        public IReportRelation LocalRelation { get; set; }
        public IReportRelation ForeignRelation { get; set; }
        public List<IReportRelationMapping> RelatedThrough { get; set; }
    }
