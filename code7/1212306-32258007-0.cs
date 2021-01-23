    namespace ClassLibrary1
    {
        public class Class1
        {
    
            public class NameRecord
            {
                public string Name;
                public string LastName;
                public int Id;
                public double DoubleValue;
            }
    
            public NameRecord[] GetObjects()
            {
                List<NameRecord> tmpResult = new List<NameRecord>(3);
                tmpResult.Add(new NameRecord { Name = "ASDF", LastName = "asdf", Id = 1, DoubleValue = 1.456789 });
                tmpResult.Add(new NameRecord { Name = "QWER", LastName = "qwer", Id = 2, DoubleValue = 2.456789 });
                tmpResult.Add(new NameRecord { Name = "YXCV", LastName = "yxcv", Id = 3, DoubleValue = 3.456789 });
                return tmpResult.ToArray();
            }
    
    
            public NameRecord[] SetObjects(string[] names,string[] lnames,int[] ids,double[] vals)
            {
                List<NameRecord> tmpResult = new List<NameRecord>();
    
                for (var i = 0; i < names.Length; i++)
                {
                    tmpResult.Add(new NameRecord { 
                        Name = names[i], 
                        LastName = lnames[i], 
                        Id = ids[i], 
                        DoubleValue = vals[i]
                    });
                }
               
                return tmpResult.ToArray();
            }
    
          
    
        }
    }
