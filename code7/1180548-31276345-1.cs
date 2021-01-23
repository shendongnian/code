    [Serializable]
    [SqlUserDefinedAggregate(
        Format.UserDefined,
        IsInvariantToOrder = true,
        IsInvariantToNulls = true,
        IsInvariantToDuplicates = true,
        MaxByteSize = -1)]
    public struct sOlder : IBinarySerialize
    {
        private struct MyData
        {
            public string Name { get; set; }
            public int? Age { get; set; }
            
            public int CompareTo(MyData other)
            {
                if (Age == null) return other.Age == null ? 0 : -1;
                if (other.Age == null) return 1;
                return Age.Value.CompareTo(other.Age.Value);
            }
            
            public static bool operator <(MyData left, MyData right)
            {
                return left.CompareTo(right) == -1;
            }
            
            public static bool operator >(MyData left, MyData right)
            {
                return left.CompareTo(right) == 1;
            }
        }
        
        private MyData _eldestPerson;
        
        public void Init()
        {
            _eldestPerson = default(MyData);
        }
        
        public void Accumulate(SqlString name, SqlInt32 age)
        {
            if (!name.IsNull && !age.IsNull)
            {
                var currentPerson = new MyData
                {
                    Name = name.Value,
                    Age = age.Value
                };
                
                if (currentPerson > _eldestPerson)
                {
                    _eldestPerson = currentPerson;
                }
            }
        }
        
        public void Merge (sOlder other)
        {
            if (other._eldestPerson > _eldestPerson)
            {
                _eldestPerson = other._eldestPerson;
            }
        }
        
        public SqlString Terminate()
        {
            return _eldestPerson.Name;
        }
        
        public void Write(BinaryWriter writer)
        {
            if (_eldestPerson.Age.HasValue)
            {
                writer.Write(true);
                writer.Write(_eldestPerson.Age.Value);
                writer.Write(_eldestPerson.Name);
            }
            else
            {
                writer.Write(false);
            }
        }
        
        public void Read(BinaryReader reader)
        {
            if (reader.ReadBoolean())
            {
                _eldestPerson.Age = reader.ReadInt32();
                _eldestPerson.Name = reader.ReadString();
            }
            else
            {
                _eldestPerson = default(MyData);
            }
        }
    }
