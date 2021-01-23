    interface INode
    {
        public string Name { get; }
        public ReadOnlyCollection<INode> Children { get; }
    }
