    public class MyEntity
    {
        public Guid MyEntityId { get; set; }
        [ForeignKey("AnotherEntityInfo")]
        public int AnotherEntityInfoId { get; set; }
        public EntityInfo AnotherEntityInfo { get; set; }
        //... some other properties
    }
