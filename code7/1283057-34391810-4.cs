    public interface INodeActor
    {
        bool CanAct(CodeTree treeNode);
        void Invoke(InvocationContext context);
    }
