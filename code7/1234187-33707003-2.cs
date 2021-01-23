    public class MyAnalyzer : DiagnosticAnalyzer
    {
        internal static DiagnosticDescriptor Rule = new DiagnosticDescriptor("CS00042", 
            "Value not allowed here",
            @"Type {0} does not allow Values in this range", 
            "type checker", 
            DiagnosticSeverity.Error,
            isEnabledByDefault: true, description: "Value to big");
        public MyAnalyzer()
        {
        }
        #region implemented abstract members of DiagnosticAnalyzer
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxTree, SyntaxKind.SimpleAssignmentExpression);
        }
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);
        #endregion
        private static void AnalyzeSyntaxTree(SyntaxNodeAnalysisContext context)
        {
            
        }
    }
