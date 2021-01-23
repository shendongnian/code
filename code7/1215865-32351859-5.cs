    public class Principal : IMaster<Permission>
    {
        public virtual IEnumerable<Permission> Permissions { get; }
        internal void RemoveDetail(Permission p)
        {
            Class.RemoveDetail(this, p);
        }
    }
