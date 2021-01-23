        internal List<GroupInfoList<object>> GetGroupsByLetter()
        {
            var groups = new List<GroupInfoList<object>>();
            var query = from item in MakeList
                        orderby ((Make)item).MakeName
                        group item by ((Make)item).MakeName[0] into g
                        select new { GroupName = g.Key, Items = g };
            foreach (var g in query)
            {
                var info = new GroupInfoList<object>();
                info.Key = g.GroupName;
                foreach (var item in g.Items)
                {
                    info.Add(item);
                }
                groups.Add(info);
            }
            return groups;
        }
    public class GroupInfoList<T> : List<object>
    {
        public object Key { get; set; }
        public new IEnumerator<object> GetEnumerator()
        {
            return (System.Collections.Generic.IEnumerator<object>)base.GetEnumerator();
        }
    }
