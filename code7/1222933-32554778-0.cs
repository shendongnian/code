    class Parent
    {
        public event ChildChangeEvent ChildChangeEvent;
        private List<Child> _children;
        public void Add(Child child)
        {
            _children.Add(child);
            ChildChangeEvent(this, child, ChangeType.Added);
        }
        public void Remove(Child child)
        {
            _children.Remove(child);
            ChildChangeEvent(this, child, ChangeType.Removed);
        }
        public void NotifyChange(Parent parent, Child child, ChangeType changeType)
        {
            //do where you want with this info.. change local id or whatever logic you need
        }
    }
