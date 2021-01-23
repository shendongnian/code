    public class ListOfGuidsUserType : IUserType
    {
        public int GetHashCode(object x)
        {
            return ((IEnumerable<Guid>)x).Count();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var value = (string)NHibernateUtil.String.Get(rs, names[0]);
            return value.Split(',').Select(Guid.Parse).ToList();
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            NHibernateUtil.String.Set(cmd, string.Join(",", (IEnumerable<Guid>)value), index);
        }
        public object DeepCopy(object value)
        {
            return ((IEnumerable<Guid>)value).ToList();
        }
        public object Replace(object original, object target, object owner)
        {
            return DeepCopy(original);
        }
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
        public SqlType[] SqlTypes
        {
            get { return SqlTypeFactory.GetString(1000); }
        }
        public Type ReturnedType
        {
            get { return typeof(IEnumerable<Guid>); }
        }
        public bool IsMutable
        {
            get { return true; }
        }
    }
