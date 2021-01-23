    public class VariablesDeclerationActor : INodeActor
    {
        public void CanAct(CodeTree node)
        {
            return node.GetType() == typeof(VariablesDecleration);
        }
    
        public void Invoke(CodeTree node)
        {
             var decl = (VariablesDecleration)node;
             // do class related stuff that has to do with VariablesDecleration
        }
    }
    public class LoopsDeclerationActor : INodeActor
    {
        public void CanAct(CodeTree node)
        {
            return node.GetType() == typeof(LoopsDecleration);
        }
    
        public void Invoke(CodeTree node)
        {
             var decl = (LoopsDecleration)node;
             // do class related stuff that has to do with LoopsDecleration
        }
    }
