    public interface INodeActor
    {
        bool CanAct(CodeTree treeNode);
        void Invoke(CodeTree treeNode);
    }
