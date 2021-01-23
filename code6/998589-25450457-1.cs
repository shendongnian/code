    public interface IEntity
        {
            [ScriptIgnore]
            string Name { get; set; }
        }
    
        public partial class Entity:IEntity
        {
        }
