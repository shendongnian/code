    var usersPagedData = new PagedData<User>("Users");
    ....
    public class PagedData<T> : DynamicObject
    {
        private string _name;
        public PagedData(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            _name = name;
        }
        public IEnumerable<T> Data { get; private set; }
        public int Count { get; private set; }
        public int CurrentPage { get; private set; }
        public int Offset { get; private set; }
        public int RowsPerPage { get; private set; }
        public int? PreviousPage { get; private set; }
        public int? NextPage { get; private set; }
        public override IEnumerable<string> GetDynamicMemberNames()
        {
            yield return _name;
            foreach (var prop in GetType().GetProperties().Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && p.Name != nameof(Data)))
            {
                yield return prop.Name;
            }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name == _name)
            {
                result = Data;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    }
