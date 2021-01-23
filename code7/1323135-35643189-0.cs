    public class SimpleAnimalEntityId : EntityId
    {
        // Implicit parameterless constructor.
    }
    public class ParametrizedAnimalEntityId : EntityId
    {
        // Parametrized constructor only.
        public ParametrizedAnimalEntityId(int ignored)
        {
        }
    }
    public abstract class EntityId
    {
        // Simple scenario: derived type has a parameterless constructor.
        public static TEntity Parse<TEntity>(string value)
            where TEntity : EntityId, new()
        {
            Guid id = Guid.Parse(value);
            return new TEntity { value = id };
        }
        // Advanced scenario: derived type constructor needs parameters injected.
        public static TEntity Parse<TEntity>(string value, Func<TEntity> constructor)
            where TEntity : EntityId
        {
            Guid id = Guid.Parse(value);
            TEntity entity = constructor();
            entity.value = id;
            return entity;
        }
        private Guid value;
        protected EntityId()
        {
            value = Guid.NewGuid();
        }
    }
