    public class First
    {
        public string Name
        {
            get;
            set;
        }
        public readonly List<Second> Children;
        public First(string name)
        {
            Name = name;
            Children = new List<Second>
            {
                new Second(1),
                new Second(2),
                new Second(3),
            };
        }
        public void AddChild(Second child)
        {
            Children.Add(child);
            ChildAdded(this, new ChildAddedEventArgs(child));
        }
        public EventHandler<ChildAddedEventArgs> ChildAdded;
    }
-------
    public class ChildAddedEventArgs //technically, not considered a model
    {
        public readonly Second ChildAdded;
        public ChildAddedEventArgs(Second childAdded)
        {
            ChildAdded = childAdded;
        }
    }
