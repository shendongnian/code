    namespace GenericIdataReader
    {
        public class MyTestObject
        {
            public int age;
            public string name;
        }
        public class mySimpleDataReader : IDataReader
        {
            private IEnumerator<MyTestObject> enumerator = null;
            public List<MyTestObject> prpLst { get; set; }
            List<MyTestObject> lst()
            {
                var rt = new List<MyTestObject>(5);
                for (int i = 0; i < rt.Capacity; i++)
                {
                    var tmp = new MyTestObject { age = i, name = "MyTestObject->"+i };
                    rt.Add(tmp);
                }
                return rt;
            }
            public mySimpleDataReader()
            {
                this.prpLst = this.lst();
                this.enumerator = this.prpLst.GetEnumerator();            
            }
            
            
            public void Close()
            {
                throw new NotImplementedException();
            }
    
            public int Depth
            {
                get { throw new NotImplementedException(); }
            }
    
            public DataTable GetSchemaTable()
            {
                throw new NotImplementedException();
            }
    
            public bool IsClosed
            {
                get { throw new NotImplementedException(); }
            }
    
            public bool NextResult()
            {
                throw new NotImplementedException();
            }
    
            public bool Read()
            {
                return enumerator.MoveNext();
            }
    
            public int RecordsAffected
            {
                get { throw new NotImplementedException(); }
            }
    
            public void Dispose()
            {
                this.enumerator.Dispose();
            }
    
            public int FieldCount
            {
                get { return 2; }// must be setted 
            }
    
            public bool GetBoolean(int i)
            {
                throw new NotImplementedException();
            }
    
            public byte GetByte(int i)
            {
                throw new NotImplementedException();
            }
    
            public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
    
            public char GetChar(int i)
            {
                throw new NotImplementedException();
            }
    
            public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
    
            public IDataReader GetData(int i)
            {
                throw new NotImplementedException();
            }
    
            public string GetDataTypeName(int i)
            {
                throw new NotImplementedException();
            }
    
            public DateTime GetDateTime(int i)
            {
                throw new NotImplementedException();
            }
    
            public decimal GetDecimal(int i)
            {
                throw new NotImplementedException();
            }
    
            public double GetDouble(int i)
            {
                throw new NotImplementedException();
            }
    
            public Type GetFieldType(int i)
            {
                 throw new NotImplementedException();
            }
    
            public float GetFloat(int i)
            {
                throw new NotImplementedException();
            }
    
            public Guid GetGuid(int i)
            {
                throw new NotImplementedException();
            }
    
            public short GetInt16(int i)
            {
                throw new NotImplementedException();
            }
    
            public int GetInt32(int i)
            {
                throw new NotImplementedException();
            }
    
            public long GetInt64(int i)
            {
                throw new NotImplementedException();
            }
    
            public string GetName(int i)
            {
               throw new NotImplementedException();
            }
    
            public int GetOrdinal(string name)
            {
               throw new NotImplementedException();
            }
    
            public string GetString(int i)
            {
                throw new NotImplementedException();
            }
    
            public object GetValue(int i) // this is where data is being pooled
            {
                if (i > 0) return enumerator.Current.name;
    // so need to create an object that will hold numeric index or simply change
    //this to return an indexed object instead of an enumerator according to parmeter i value
                return enumerator.Current.age;
            }
    
            public int GetValues(object[] values)
            {
                throw new NotImplementedException();
            }
    
            public bool IsDBNull(int i)
            {
                throw new NotImplementedException();
            }
    
            public object this[string name]
            {
                get { throw new NotImplementedException(); }
            }
    
            public object this[int i]
            {
                get { throw new NotImplementedException(); }
            }
        }
       
    }
