    class Master
    {
        private List<Parent> _parents;
        public void AddParent(Parent parent)
        {
            _parents.Add(parent);
            parent.ChildChangeEvent += parent_ChildChangeEvent;
        }
        void parent_ChildChangeEvent(Parent parent, Child child, ChangeType changeType)
        {
            foreach (var notifyParent in _parents)
            {
                notifyParent.NotifyChange(parent, child, changeType);
            }
        }
    }
