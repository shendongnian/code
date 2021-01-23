    namespace SpecificNamespace
    {
        public interface IUtilityObject
        {
            int Id { get; set; }
        }
    
        class UtilityObject : IUtilityObject
        {
            //properties
            public int Id { get; set; }
        }
    
        public abstract class Entity
        {
            protected void doStuff(IUtilityObject utilityObject)
            {
                //does stuff
            }
        }
    
        // include implementations of Entity
    }
