    async Task Test()
    {
        var ws = new AdhocWorkspace();
        var proj = ws.AddProject("test", "C#");
        var tree = SyntaxFactory.ParseSyntaxTree(@"
    public class Program
    {
        public static void Main()
        {
            var i = System.Environment.GetCommandLineArgs().Length;
            switch (i)
            {
                case 1: goto case 2;
                case 2: goto default;
                case 3: goto wat;
                default: break;
            }
    wat:
            return;
        }
    }");
        var root = tree.GetRoot();
        var doc = proj.AddDocument("file1.cs", root);
        proj = doc.Project.AddMetadataReference(MetadataReference.CreateFromFile(typeof(object).Assembly.Location));
    
        var compilation = await proj.GetCompilationAsync();
        var model = compilation.GetSemanticModel(tree);
    
        var walker = new Walker { Model = model };
        walker.Visit(root);
    }
    
    class Walker : CSharpSyntaxWalker
    {
        public SemanticModel Model { get; set; }
    
        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            var name = node.CaseOrDefaultKeyword.ValueText != null
                ? string.Join(" ", new[] { node.CaseOrDefaultKeyword.Text, node.Expression?.ToString() }.Where(x => x != null)) +  ":"
                : node.Expression.ToString();
            var label = Model.LookupLabels(node.SpanStart, name).OfType<ILabelSymbol>().SingleOrDefault();
    
            var label2 = ((IBranchStatement)Model.GetOperation(node)).Target;
            // (label == label2).Dump();
    
            base.VisitGotoStatement(node);
        }
    }
