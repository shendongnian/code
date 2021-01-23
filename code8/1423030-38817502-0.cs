    [Serializable]
    public class CustomThingUserType : IUserType {
        public new bool Equals(object x, object y) {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.Equals(y);
        }
        public int GetHashCode(object x) {
            if (x == null)
                return 0;
            return x.GetHashCode();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner) {
            if (names.Length == 0)
                throw new ArgumentException("Expecting at least one column");
            int id = (int)NHibernateUtil.Int32.NullSafeGet(rs, names[0]);
            var obj = new CustomThing { Id = id };
            // here you can grab your data from external service
            return obj;
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index) {
            var parameter = (DbParameter)cmd.Parameters[index];
            if (value == null) {
                parameter.Value = 0;
            }
            else {
                parameter.Value = ((CustomThing)value).Id;
            }
        }
        public object DeepCopy(object value) {
            return value;
        }
        public object Replace(object original, object target, object owner) {
            return original;
        }
        public object Assemble(object cached, object owner) {
            return cached;
        }
        public object Disassemble(object value) {
            return value;
        }
        public SqlType[] SqlTypes {
            get {
                return new SqlType[] { new SqlType(DbType.Int32) };
            }
        }
        public Type ReturnedType {
            get { return typeof(CustomThing); }
        }
        public bool IsMutable {
            get { return false; }
        }
    }
