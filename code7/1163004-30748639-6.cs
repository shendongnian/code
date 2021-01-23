    public class CollFilter : FilterDefinition
    {
        public CollFilter()
        {
            WithName("CollFilter")
                .WithCondition("PricingIncrement_id = :pricingIncrementId")
                .AddParameter("pricingIncrementId",NHibernate.Int32);
        }
    } 
