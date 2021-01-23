    //Dummy class representing your data.
    //
    //Notice that I made the IEqualityComparer as a child class only
    //for the sake of demonstration
    public class DataObject 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public static List<PropertyInfo> GetProps()
        {
            //Only return a subset of the DataObject class properties, simulating your List<PropertyInfo>
            return typeof(DataObject).GetProperties().Where(p => p.Name == "Name" || p.Name == "Grade").ToList();
        }
        public class DataObjectComparer : IEqualityComparer<DataObject>
        {
            public bool Equals(DataObject x, DataObject y)
            {
                if (x == null || y == null)
                    return false;
                foreach (PropertyInfo pi in DataObject.GetProps())
                {
                    if (!pi.GetValue(x).Equals(pi.GetValue(y)))
                        return false;
                }
                return true;
            }
            public int GetHashCode(DataObject obj)
            {
                int hash = 17;
                foreach (PropertyInfo pi in DataObject.GetProps())
                {
                    hash = hash * 31 + pi.GetValue(obj).GetHashCode();
                }
                return hash;
            }
        }
    }
    //Then use that in your code:
    //
    List<DataObject> lst = new List<DataObject>();
    lst.Add(new DataObject { Name = "Luc", Age = 49, Grade = 100 });
    lst.Add(new DataObject { Name = "Luc", Age = 23, Grade = 100 });
    lst.Add(new DataObject { Name = "Dan", Age = 49, Grade = 100 });
    lst.Add(new DataObject { Name = "Dan", Age = 23, Grade = 100 });
    lst.Add(new DataObject { Name = "Luc", Age = 20, Grade = 80 });
    List<DataObject> dist = lst.GroupBy(p => p, new DataObject.DataObjectComparer()).Select(g => g.First()).ToList();
    
