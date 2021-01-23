    public class ScopeContext<TArg,TRet>{
        public dynamic Scope {get;set;}
        public Func<TArg,TRet> Expression;
         
        public ScopeContext(string exp){
            TypeRegistry tr = new TypeRegistry();
            tr.RegisterSymbole("scope",Scope);
            Expression = (new CompiledExpression<TRet>(exp)
            {
                TypeRegistry = tr
            }).ScopeCompile<TArg>();
        }
    }
    // usage
    ScopeContext<object,object> f = 
         new ScopeContext<object,object>("scope.Count");
    // you can now change scope dynamically...
    f.Scope = new List<int>();
    var result = f.Expression(null);
