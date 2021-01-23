    namespace DomainNameSpace 
    {
        public partial class BaseEntity
        {
            public enum ObjectState
            {
                Unchanged,
                Added,
                Modified,
                Deleted
            }
            public interface IObjectState
            {
                [NotMapped]
                ObjectState ObjectState { get; set; }
            }
        }
    }
