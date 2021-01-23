    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AssignAllPropertiesAnalyzer : DiagnosticAnalyzer
    {
        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor("AssignAllPropertiesAnalyzer",
            "All properties must be assigned.", "All properties of the return type must be assigned.", "Correctness", 
            DiagnosticSeverity.Warning, isEnabledByDefault: true);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
        }
        private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
        {
            var methodNode = (MethodDeclarationSyntax)context.Node;
            var methodSymbol = context.SemanticModel.GetDeclaredSymbol(methodNode);
            if (methodSymbol.GetReturnTypeAttributes().Any(x => x.AttributeClass.Name == "AssignAllPropertiesAttribute"))
            {
                var properties = methodSymbol.ReturnType.GetMembers().OfType<IPropertySymbol>().Where(x => !x.IsReadOnly).ToList();
                foreach (var assignmentNode in methodNode.DescendantNodes().OfType<AssignmentExpressionSyntax>())
                {
                    var propertySymbol = context.SemanticModel.GetSymbolInfo(assignmentNode.Left).Symbol as IPropertySymbol;
                    if (propertySymbol != null)
                    {
                        properties.Remove(propertySymbol);
                    }
                }
                if (properties.Count > 0)
                {
                    var diagnostic = Diagnostic.Create(Rule, methodSymbol.Locations[0]);
                    context.ReportDiagnostic(diagnostic);
                }
            }
        }
