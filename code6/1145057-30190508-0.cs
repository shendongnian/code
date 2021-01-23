    public interface IMyRepository
    {
        bool TryGetNameById(int id, out string name);
    }
    
    public class FakeRepository : IMyRepository
    {
        // public on purpose, this is for testing after all
        public readonly Dictionary<int, string> nameByIds = new Dictionary<int, string>();
    
        // important to make all methods/properties virtual that are part of the interface implementation
        public virtual bool TryGetNameById(int id, out string name)
        {
            return this.nameByIds.TryGetValue(id, out name);
        }
    }
