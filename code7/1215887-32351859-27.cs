    public class Principal : IMaster<Permission>
    {
        public virtual IEnumerable<Permission> Permissions { get; }
        public void RemoveDetail(Permission p)
        {
            Class.RemoveDetail(this, p);
        }
    }
