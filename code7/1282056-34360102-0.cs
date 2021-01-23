    public static class Ex
    {
        public static List<MyClass> FindNode(this MyClass t, string id)
        {
            if (t.Id == id)
                return new List<MyClass>() { t };
            if (t.Children == null)
                return null;
            foreach (var child in t.Children)
            {
                var childResult = child.FindNode(id);
                if (childResult != null)
                    return new List<MyClass>() { t }.Concat(childResult).ToList();
            }
            return null;
        }
    }
