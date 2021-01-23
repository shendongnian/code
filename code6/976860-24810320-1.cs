    var list1 = new List<MyItem>();
    var list2 = new List<MyItem>();
        
    var listWhereNamesMatch = list1.Intersect(list2);
        
    
    // implement IEquatable within your class
    class MyItem : IEquatable<MyItem>
    {
        public string Name { get; set; }
        bool IEquatable<MyItem>.Equals(MyItem other)
        {
            return this.Name == other.Name;
        }
    }
