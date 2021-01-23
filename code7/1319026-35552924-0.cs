        using Microsoft.SqlServer.TransactSql.ScriptDom;
        using System.Reflection;
        public class CustomVisitor : TSqlFragmentVisitor
        {
            private void DoSomething(dynamic obj)
            {
                foreach (var property in obj.GetType().
                    GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    // Recursively analyse object model to find specific objects
                }
            }
            // Generic statement
            public override void Visit(TSqlStatement node)
            {
                DoSomething(node);
                base.Visit(node);
            }
        }
    // Generic statement
    public override void Visit(TSqlStatement node)
    {
        DoSomething(node);
        base.Visit(node);
    }
}
