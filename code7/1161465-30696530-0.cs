    public interface IMyObject : ICollection<IMyObject>
    {
    }
    public class MyFileObject : MyAbstractFileObject 
    {
        public MyFileObject(string displayName)
            : base(displayName) 
        {
        }
    }
    public abstract class MyAbstractFileObject : IMyObject
    {
        private ICollection<IMyObject> children;
        public MyFileObject(string displayName)
        {
            this.DisplayName = displayName;
            this.children= new Collection<IMyObject>();
        }
        public IMyObject Parent { get; protected set; }
        public string DisplayName { get; protected set; }
        
        public void Add(IMyObject child)
        {
            this.children.Add(child);
            child.Parent = this;
        }
        public void Remove(IMyChild child)
        {
            this.children.Remove(child);
            child.Parent = null;
        }
        // other ICollection<IMyObject> members
    }
