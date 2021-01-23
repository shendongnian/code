        class Program
        {
            static void Main(string[] args)
            {
                var list1 = new List<Item>
                {
                    new Item {Name = "A", IsSelected = true},
                    new Item {Name = "B", IsSelected = false},
                    new Item {Name = "C", IsSelected = true}
                };
    
                var list2 = new List<Item>
                {
                    new Item {Name = "A", IsSelected = true},
                    new Item {Name = "C", IsSelected = true},
                    new Item {Name = "D", IsSelected = false}
                };
    
                var list3 = new List<Item>
                {
                    new Item {Name = "B", IsSelected = true},
                    new Item {Name = "E", IsSelected = false},
                    new Item {Name = "F", IsSelected = false}
                };
    
                var itemContainer = new ItemContainer();
                itemContainer.items = list1.Concat(list2).Concat(list3)
                    .Distinct()
                    .OrderBy(item => item.Name)
                    .ThenByDescending(item => item.IsSelected)
                    .ToList();
    
                //new list of items will contain 7 items:
                // A,true
                // B,false
                // B,true
                // C,true
                // D,false
                // E,false
                // F,false
            }
        }
    
        public class Item
        {
            public string Name;
            public bool IsSelected;
    
            public override int GetHashCode()
            {
                return Name.GetHashCode() * IsSelected.GetHashCode();
            }
    
            public override bool Equals(object obj)
            {
                var objItem = obj as Item;
                return objItem != null && objItem.Name == Name && objItem.IsSelected == IsSelected;
            }
        }
    
        public class ItemContainer
        {
            public string Name;
            public IList<Item> items;  //items with the same 'Name' (potentially)
        }
