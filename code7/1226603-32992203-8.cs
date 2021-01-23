    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.Common;
    using Newtonsoft.Json;
    using NHibernate.UserTypes;
    using NHibernate.SqlTypes;
    
    [Serializable]
    public class StoreDynamicProperties : IUserType
    {
        private JsonSerializerSettings _settings = new JsonSerializerSettings(); // { TypeNameHandling = TypeNameHandling.All };
        public new bool Equals(object x, object y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            var xdocX = JsonConvert.SerializeObject((IDictionary<string, object>)x, _settings);
            var xdocY = JsonConvert.SerializeObject((IDictionary<string, object>)y, _settings);
            return xdocY == xdocX;
        }
        public int GetHashCode(object x)
        {
            if (x == null)
                return 0;
            return x.GetHashCode();
        }
        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            if (names.Length != 1)
                throw new InvalidOperationException("Only expecting one column…");
            var val = rs[names[0]] as string;
            if (val != null && !string.IsNullOrWhiteSpace(val))
            {
                return JsonConvert.DeserializeObject<IDictionary<string, object>>(val, _settings);
            }
            return null;
        }
        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var parameter = (DbParameter)cmd.Parameters[index];
            if (value == null)
            {
                parameter.Value = DBNull.Value;
            }
            else
            {
                parameter.Value = JsonConvert.SerializeObject((IDictionary<string, object>)value, _settings);
            }
        }
        public object DeepCopy(object value)
        {
            if (value == null)
                return null;
            //Serialized and Deserialized using json.net so that I don't
            //have to mark the class as serializable. Most likely slower
            //but only done for convenience. 
            var serialized = JsonConvert.SerializeObject((IDictionary<string, object>)value, _settings);
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(serialized, _settings);
        }
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
        public object Assemble(object cached, object owner)
        {
            var str = cached as string;
            if (string.IsNullOrWhiteSpace(str))
                return null;
            return JsonConvert.DeserializeObject<IDictionary<string, object>>(str, _settings);
        }
        public object Disassemble(object value)
        {
            if (value == null)
                return null;
            return JsonConvert.SerializeObject((IDictionary<string, object>)value);
        }
        public SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[] { new StringSqlType(8000) };
            }
        }
        public Type ReturnedType
        {
            get { return typeof(IDictionary<string, object>); }
        }
        public bool IsMutable
        {
            get { return true; }
        }
    }
