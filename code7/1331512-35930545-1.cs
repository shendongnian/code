    public abstract class AdjacencyTreeBase<T> where T : AdjacencyTreeBase<T>
    {
        public AdjacencyTreeBase(int entityId, int entityTypeId)
        {
            EntityId = entityId;
            EntityTypeId = entityTypeId;
        }
    
        public long? Id { get; set; }
        public int? SystemId { get; set; }
        public int EntityId { get; set; }
        public int EntityTypeId { get; set; }
        public bool? isActive { get; set; }
        public long? lft { get; set; }
        public long? rgt { get; set; }
    
        public abstract void AddChild(T c);
        public abstract void RemoveChild(T c);
        public abstract List<T> ListChildren();
        public abstract void AddChildren(List<T> c);
        public abstract void ReplaceChildren(List<T> c);
    }
    
    public abstract class AdjacencyTree : AdjacencyTreeBase<AdjacencyTree>
    {
        private List<AdjacencyTree> _children = new List<AdjacencyTree>();
        public List<AdjacencyTree> Children { get { return _children; } set { _children = value; } }
    
        public AdjacencyTree(int entityId, int entityTypeId) : base(entityId, entityTypeId) { }
    
        public override void AddChild(AdjacencyTree component)
        {
            _children.Add(component);
        }
        public override void AddChildren(List<AdjacencyTree> c)
        {
            _children = c;
        }
        public override void ReplaceChildren(List<AdjacencyTree> c)
        {
            _children = c;
        }
        public override void RemoveChild(AdjacencyTree component)
        {
            _children.Remove(component);
        }
        public override List<AdjacencyTree> ListChildren()
        {
            return _children;
        }
    }
    
    public class AdjacencyAgency : AdjacencyTree
    {
        public string agency_name { get; set; }
        public string customer_number { get; set; }
        public string agency_type { get; set; }
    
        public AdjacencyAgency(int entityId, int entityTypeId) : base(entityId, entityTypeId)
        {
        }
    }
    
    public class AdjacencyUser : AdjacencyTree
    {
        public string officer_number { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
    
        public AdjacencyUser(int entityId, int entityTypeId) : base(entityId, entityTypeId)
        {
        }
    }
    
    public class AdjacencyClient : AdjacencyTree
    {
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_initial { get; set; }
        public string ssn { get; set; }
    
        public AdjacencyClient(int entityId, int entityTypeId) : base(entityId, entityTypeId)
        {
        }
    }
