    public class ItemPathResolver
    {
        public virtual Item ResolveItem(string path, Item root)
        {
            return DoResolveItem(path.Split(new char[1]
            {
                '/'
            }, StringSplitOptions.RemoveEmptyEntries).ToList(), root);
        }
        protected virtual Item DoResolveItem(List<string> pathParts, Item root)
        {
            if (!pathParts.Any() || root == null)
                return root;
            string str = pathParts.First();
            List<string> range = pathParts.GetRange(1, pathParts.Count - 1);
            Item child1 = GetChild(root, str);
            Item obj = DoResolveItem(range, child1);
            if (obj == null)
            {
                string itemName = MainUtil.DecodeName(str);
                if (str != itemName)
                {
                    Item child2 = GetChild(root, itemName);
                    obj = DoResolveItem(range, child2);
                }
            }
            return obj;
        }
        protected virtual Item GetChild(Item item, string itemName)
        {
            foreach (Item obj in item.Children)
            {
                if (obj.Name.Equals(itemName, StringComparison.InvariantCultureIgnoreCase))
                    return obj;
            }
            return null;
        }
    }
