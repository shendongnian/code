    class MyClass
    {
        string id;
        List<MyClass> children;
        MyClass parent;
        public MyClass(string id, List<MyClass> children)
        {
            this.id = id;
            this.children = children;
            foreach (var child in children)
            {
                child.parent = this;
            }
        }
        public MyClass Parent { get { return this.parent; } }
        public string Id { get { return this.id; } }
        public List<MyClass> Children { get { return this.children; } }
    }
    static class Utility
    {
        public static MyClass FindMyClassById(IEnumerable<MyClass> myClasses, string id)
        {
            foreach (var myClass in myClasses)
            {
                if (myClass.Id == id)
                {
                    return myClass;
                }
                if (myClass.Children != null && myClass.Children.Any())
                {
                    return FindMyClassById(myClass.Children, id);
                }
            }
            return null;
        }
        public static MyClass[] GetParentNodes(MyClass myClass)
        {
            var parents = new List<MyClass>();
            while (myClass != null)
            {
                myClass = myClass.Parent;
                parents.Add(myClass);
            }
            return parents.ToArray();
        }
    }
