    class Program
    {
        static void Main(string[] args)
        {
            var composer1 = new ComposerA(new Dictionary<Type, Func<CodeTree, string>>()
            {
                { typeof(VariablesDeclaration), SomeVariableAction },
                { typeof(LoopsDeclaration), SomeLoopAction }
            });
    
            var composer2 = new ComposerB(new Dictionary<Type, Func<CodeTree, string>>()
            {
                { typeof(VariablesDeclaration), SomeOtherAction }
    
            });
    
            var snippet1 = composer1.GenerateSnippet(new CodeTree() {Codes = new List<CodeTree>() {new LoopsDeclaration(), new VariablesDeclaration()}});
            var snippet2 = composer2.GenerateSnippet(new CodeTree() { Codes = new List<CodeTree>() { new VariablesDeclaration() } });
    
            Debug.WriteLine(snippet1); // "Some loop action Some variable action  some composer A spice"
            Debug.WriteLine(snippet2); // "Some other action  some composer B spice"
        }
    
        static string SomeVariableAction(CodeTree tree)
        {
            return "Some variable action ";
        }
    
        static string SomeLoopAction(CodeTree tree)
        {
            return "Some loop action ";
        }
    
        static string SomeOtherAction(CodeTree tree)
        {
            return "Some other action ";
        }
    }
    
    public interface IComposer
    {
        string GenerateSnippet(CodeTree tree);
    }
    
    public class CodeTree
    {
        public List<CodeTree> Codes;
    }
    
    public class ComposerBase
    {
        protected Dictionary<Type, Func<CodeTree, string>> _actions;
    
        public ComposerBase(Dictionary<Type, Func<CodeTree, string>> actions)
        {
            _actions = actions;
        }
    
        public virtual string GenerateSnippet(CodeTree tree)
        {
            var result = "";
    
            foreach (var codeTree in tree.Codes)
            {
                result = string.Concat(result, _actions[codeTree.GetType()](tree));
            }
    
            return result;
        }
    }
    
    public class ComposerA : ComposerBase
    {
        public ComposerA(Dictionary<Type, Func<CodeTree, string>> actions) : base(actions)
        {
        }
    
        public override string GenerateSnippet(CodeTree tree)
        {
            var result = base.GenerateSnippet(tree);
                
            return string.Concat(result, " some composer A spice");
        }
    }
    
    public class ComposerB : ComposerBase
    {
        public ComposerB(Dictionary<Type, Func<CodeTree, string>> actions) : base(actions)
        {
        }
    
        public override string GenerateSnippet(CodeTree tree)
        {
            var result = base.GenerateSnippet(tree);
    
            return string.Concat(result, " some composer B spice");
        }
    }
    
    public class VariablesDeclaration : CodeTree
    {
        //Impl
    }
    
    public class LoopsDeclaration : CodeTree
    {
        //Impl
    }
