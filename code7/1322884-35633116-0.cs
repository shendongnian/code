    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SelfAssignmentAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SelfAssignment";
        private static readonly LocalizableString Title = "Do not do self assignment";
        private static readonly LocalizableString MessageFormat = "The variable '{0}' is assigned to itself";
        private static readonly LocalizableString Description = "A variable assignment to itself is likely an indication of a larger error.";
        private const string Category = "Correctness";
        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.SimpleAssignmentExpression);
        }
        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var assignmentExpr = (AssignmentExpressionSyntax)context.Node;
            if(assignmentExpr.OperatorToken.Text != "=")
                return;
            var right = context.SemanticModel.GetSymbolInfo(assignmentExpr.Right);
            var left = context.SemanticModel.GetSymbolInfo(assignmentExpr.Left);
            if (!right.Equals(left))
                return;
            var diagnostic = Diagnostic.Create(Rule, assignmentExpr.GetLocation(), assignmentExpr.Left.ToString());
            context.ReportDiagnostic(diagnostic);
        }
    }
