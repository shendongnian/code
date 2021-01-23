            var list1 = new List<MyItem>();
            var list2 = new List<MyItem>();
        
            var listWhereNamesMatch = list1.Intersect(list2, new ItemComparer());
        
    
    // other classes
    
            class MyItem
            {
                public string Name { get; set; }
            }
        
            class ItemComparer : IEqualityComparer<MyItem>
            {
                public bool Equals(MyItem item1, MyItem item2)
                {
                    return item1.Name == item2.Name;
                }
        
                public int GetHashCode(MyItem item)
                {
                    return item.Name.GetHashCode();
                }
            }
