    using System;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.IO;
    
    [Serializable]
    [SqlUserDefinedAggregate(Format.UserDefined, Name = "sMaxDatetime", MaxByteSize = -1)] 
    public struct SO33215409 : IBinarySerialize
    {
        private SqlString _data;
        private SqlDateTime _latest;
        public void Init()
        {
            _data = SqlString.Null;
            _latest = SqlDateTime.MinValue;
        }
    
        public void Accumulate(SqlString data, SqlDateTime dt)
        {
            if (dt > _latest)
            {
                _data = data;
                _latest = dt;
            }
        }
    
        public void Merge (SO33215409 Group)
        {
            if (Group._latest > _latest)
            {
                _data = Group._data;
                _latest = Group._latest;
            }
        }
    
        public SqlString Terminate ()
        {
            return _data;
        }
    
        public void Write (BinaryWriter w)
        {
            w.Write(_data.IsNull);
            w.Write(_latest.IsNull);
            if (_data.IsNull == false)
            {
                w.Write(_data.Value);
            }
            if (_latest.IsNull == false)
            {
                w.Write(_latest.Value.Ticks);
            }
        }
        public void Read(BinaryReader r)
        {
            bool dataIsNull = r.ReadBoolean();
            bool latestIsNull = r.ReadBoolean();
            if (dataIsNull)
            {
                _data = SqlString.Null;
            }
            else
            {
                _data = r.ReadString();
            }
            if (latestIsNull)
            {
                _latest = SqlDateTime.Null;
            }
            else
            {
                DateTime d = new DateTime(r.ReadInt64());
                _latest = new SqlDateTime( d );
            }
        }
    }
