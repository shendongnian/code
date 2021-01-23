    public class RecentFilter : FilterDefinition
    {
        public RecentFilter()
        {
            WithName("RecentFilter")
                .WithCondition("( :EndedAtDate IS NULL OR EndedAt < :EndedAtDate )")
                .AddParameter("EndedAtDate",NHibernate.NHibernateUtil.DateTime);
        }
    }
