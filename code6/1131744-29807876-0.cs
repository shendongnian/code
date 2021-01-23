    static class ListExtensions
    {
        /// <summary>
        /// Load List Item by Url 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static ListItem LoadItemByUrl(this List list, string url)
        {
            var context = list.Context;
            var query = new CamlQuery
            {
                ViewXml = String.Format("<View><RowLimit>1</RowLimit><Query><Where><Eq><FieldRef Name='FileRef'/><Value Type='Url'>{0}</Value></Eq></Where></Query></View>", url),
            };
            var items = list.GetItems(query);
            context.Load(items);
            context.ExecuteQuery();
            return items.Count > 0 ? items[0] : null;
        }
    }  
 
