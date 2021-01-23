    class ActionNode : TreeNode
    {
        public Action Action { get; }
        public ActionNode(string text, Action action)
            : base(text)
        {
            Action = action;
        }
    }
