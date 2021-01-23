    public abstract class BaseEntity<TSubclass> where TSubclass : BaseEntity<TSubclass>
	{
        public abstract object ID { get; }
        public virtual Expression<Func<TSubclass, object>> UpdateCriterion()
        {
            return entity => entity.ID;
        }
    }
    public partial class Foo : BaseEntity<Foo>
    {
        public Int32 FooId { get; set; }
        public override object ID { get { return FooId; } } 
    }
