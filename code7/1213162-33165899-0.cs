    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Diagnostics.Eventing.Reader;
    using System.Globalization;
    using Microsoft.SqlServer.Server;
    using System.Text;
    using System.Collections;
    using System.IO;
    [Serializable]
    [SqlUserDefinedAggregate(
        Format.UserDefined,
        IsInvariantToOrder = true,
        IsInvariantToNulls = true,
        IsInvariantToDuplicates = true,
        MaxByteSize = -1)]
    public struct sMax : IBinarySerialize, INullable
    {
        #region Helpers
        private struct MyData
        {
            public object Data { get; set; }
            public InType DataType { get; set; }
            public object Group { get; set; }
            public InType GroupType { get; set; }
            public int CompareTo(MyData other)
            {
                if (Group == null)
                    return other.Group == null ? 0 : -1;
                if (other.Group == null)
                    return 1;
                if (GroupType == InType.Int)
                    return Convert.ToInt32(Group).CompareTo(Convert.ToInt32(other.Group));
                if (GroupType == InType.BigInt)
                    return Convert.ToInt64(Group).CompareTo(Convert.ToInt64(other.Group));
                if (GroupType == InType.Double)
                    return Convert.ToDouble(Group).CompareTo(Convert.ToDouble(other.Group));
                if (GroupType == InType.Date)
                    return Convert.ToDateTime(Group.ToString()).CompareTo(Convert.ToDateTime(other.Group.ToString()));
                if (GroupType == InType.String)
                    return Convert.ToString(Group).CompareTo(Convert.ToString(other.Group));
                else
                    return 0;
            }
            public static bool operator < (MyData left, MyData right)
            {
                return left.CompareTo(right) == -1;
            }
            public static bool operator > (MyData left, MyData right)
            {
                return left.CompareTo(right) == 1;
            }
        }
        private enum InType
        {
            String,
            Int,
            BigInt,
            Date,
            Double,
            Unknow
        }
        private InType GetType(object value)
        {
            if (value.GetType() == typeof(SqlInt32))
                return InType.Int;
            else if (value.GetType() == typeof(SqlInt64))
                return InType.BigInt;
            else if (value.GetType() == typeof(SqlString))
                return InType.String;
            else if (value.GetType() == typeof(SqlDateTime))
                return InType.Date;
            else if (value.GetType() == typeof(SqlDouble))
                return InType.Double;
            else
                return InType.Unknow;
        }
        #endregion
        private MyData _maxItem;
        public void Init()
        {
            _maxItem = default(MyData);
            this.IsNull = true;
        }
        public void Accumulate(object data, object group)
        {
            if (data != null && group != null)
            {
                var current = new MyData
                {
                    Data = data,
                    Group = group,
                    DataType = GetType(data),
                    GroupType = GetType(group)
                };
                if (current > _maxItem)
                {
                    _maxItem = current;
                }
            }
        }
        public void Merge(sMax other)
        {
            if (other._maxItem > _maxItem)
            {
                _maxItem = other._maxItem;
            }
        }
        public SqlString Terminate()
        {
            return this.IsNull ? SqlString.Null : new SqlString(_maxItem.Data.ToString());
        }
        public void Read(BinaryReader reader)
        {
            IsNull = reader.ReadBoolean();
            _maxItem.Group = reader.ReadString();
            _maxItem.Data = reader.ReadString();
            if (_maxItem.Data != null)
                this.IsNull = false;
        }
        public void Write(BinaryWriter writer)
        {
            writer.Write(this.IsNull);
            writer.Write(_maxItem.Group.ToString());
            writer.Write(_maxItem.Data.ToString());
        }
        public Boolean IsNull { get; private set; }
    }
