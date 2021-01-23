    public abstract class BaseEntity<TSubClass>
    {
        public abstract object ID { get; }
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
