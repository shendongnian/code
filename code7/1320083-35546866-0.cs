     static class Program
        {
            public static void Main()
            {
    
                IEnumerable<InputClass> allItems = someBLL.GetAllItems();
    
                int? someParentNode = 1;
    
                var allChildItems = InputClass.GetAllChildNodesRecursivrly(someParentNode, allItems);
    
            }
        }
    
        public class InputClass
        {
            public int id { get; set; }
            public string text { get; set; }
            public string icon { get; set; }
            public int? parentId { get; set; }
    
            public static IEnumerable<InputClass> GetAllChildNodesRecursivrly(int? ParentId,IEnumerable<InputClass> allItems)
            {
                var allChilds = allItems.Where(i => i.parentId == ParentId);
    
                if (allChilds==null)
                {
                    return new List<InputClass>();
                }
    
                List<InputClass> moreChildes = new List<InputClass>();
                foreach (var item in allChilds)
                {
                    moreChildes.AddRange(GetAllChildNodesRecursivrly(item.id,allItems));
                }
    
                return allChilds.Union(moreChildes);
            }
        }
