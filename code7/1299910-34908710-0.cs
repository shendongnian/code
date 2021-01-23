    public abstract class Entity
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
    }
    public class A : Entity
    {
        public string SomeProperty { get; set; }
    }
    public class B : Entity
    {
        public string AnotherProperty { get; set; }
    }
    public abstract class Rep<T> where T : Entity
    {
        public abstract void Add(T entity);
        public abstract void Delete(T entity);
        public virtual void SaveChanges(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case "Added":
                        Add(entity);
                        break;
                    case "Deleted":
                        Delete(entity);
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid entity state {entity.State}");
                }
            }
        }
    }
    public class RepA : Rep<A>
    {
        public override void Add(A entity)
        {
            // some specific logic here
        }
        public override void Delete(A entity)
        {
            // some specific logic here
        }
    }
    public class RepB : Rep<B>
    {
        public override void Add(B entity)
        {
            // some specific logic here
        }
        public override void Delete(B entity)
        {
            // some specific logic here
        }
    }
    public class Program
    {
        private static readonly RepA _repA = new RepA();
        private static readonly RepB _repB = new RepB();
        public static void Main()
        {
            var entities = new List<Entity>();
            // fill the list here
            _repA.SaveChanges(entities.OfType<A>());
            _repB.SaveChanges(entities.OfType<B>());
        }
    }
