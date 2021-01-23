    public class Header
    {
        public string HeaderTitle { get; set; }
    
        public Header()
        {
            HeaderTitle = string.Empty;
        }
    
        public static ObservableCollection<Text> GetTexts()
        {
            ObservableCollection<Text> myListOfData = new ObservableCollection<Text>();    
            myListOfData.Add(new Text("Product1"));    
            myListOfData.Add(new Text("Product2"));    
            myListOfData.Add(new Text("Product3"));
            myListOfData.Add(new Text("Setting1"));
            myListOfData.Add(new Text("Setting2"));
            myListOfData.Add(new Text("Setting3"));
            myListOfData.Add(new Text("Setting4"));
            return myListOfData;
        }
    
        public static ObservableCollection<GroupInfoList> GetItemsGrouped()
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();
    
            var query = from item in GetTexts()
                        group item by item.Title[0] into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };
    
            foreach (var g in query)
            {
                GroupInfoList info = new GroupInfoList();
                if (g.GroupName.ToString() == "P")
                {
                    info.Key = "Products";
                }
                else if (g.GroupName.ToString() == "S")
                {
                    info.Key = "Settings";
                }
                else
                {
                    info.Key = g.GroupName;
                }
    
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }
            return groups;
        }
    }
