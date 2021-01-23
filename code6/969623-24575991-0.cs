    public partial class BaseEntity<TSubClass>
    {
        private object id;
        public virtual object ID { get { return id; } }
        public virtual Expression<Func<TSubclass, object>> UpdateCriterion()
        {
            return entity => entity.ID;
        }
    }
    public partial class Foo : BaseEntity 
    {
        public Integer FooId { get; set; }
        public override ID { get { return FooId; } } 
    }
