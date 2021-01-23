    public class Headers
    {
        public string HeaderTitle { get; set; }
    
        public Headers()
        {
            HeaderTitle = string.Empty;
        }
    
        private static List<string> urls = new List<string>
        {
            "http://favorite.com",
            "http://new.com",
            "http://feature.com",
            "http://favorite.book1.com",
            "http://new.book2.com",
            "http://feature.book3.com",
            "http://favorite.book4.com",
            "http://new.book5.com",
        };
    
        public static ObservableCollection<BookList> GetCollection()
        {
            ObservableCollection<BookList> myBookList = new ObservableCollection<BookList>();
            foreach (var book in urls)
            {
                myBookList.Add(new BookList(book));
            }
            return myBookList;
        }
    
        public static ObservableCollection<GroupInfoList> GetItemsGrouped()
        {
            ObservableCollection<GroupInfoList> groups = new ObservableCollection<GroupInfoList>();
    
            var query = from item in GetCollection()
                        group item by item.BookAddress[9] into g
                        orderby g.Key
                        select new { GroupName = g.Key, Items = g };
    
            foreach (var g in query)
            {
                GroupInfoList info = new GroupInfoList();
    
                switch (g.GroupName.ToString())
                {
                    case "v":
                        info.Key = "Favorite";
                        break;
    
                    case "w":
                        info.Key = "New";
                        break;
    
                    case "a":
                        info.Key = "Feature";
                        break;
    
                    default:
                        info.Key = g.GroupName;
                        break;
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
