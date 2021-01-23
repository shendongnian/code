    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class RequiredBaseMethodCallAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "RequireBaseMethodCall";
        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Usage";
        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }
        public override void Initialize(AnalysisContext context)
        {
            context.RegisterCompilationStartAction(AnalyzeMethodForBaseCall);
        }
        private static void AnalyzeMethodForBaseCall(CompilationStartAnalysisContext compilationStartContext)
        {
            compilationStartContext.RegisterSyntaxNodeAction(AnalyzeMethodDeclaration, SyntaxKind.MethodDeclaration);
        }
        private static void AnalyzeMethodDeclaration(SyntaxNodeAnalysisContext context)
        {
            var mds = context.Node as MethodDeclarationSyntax;
            if (mds == null)
            {
                return;
            }
            IMethodSymbol symbol = context.SemanticModel.GetDeclaredSymbol(mds) as IMethodSymbol;
            if (symbol == null)
            {
                return;
            }
            if (!symbol.IsOverride)
            {
                return;
            }
            if (symbol.OverriddenMethod == null)
            {
                return;
            }
            var overridenMethod = symbol.OverriddenMethod;
            var attrs = overridenMethod.GetAttributes();
            if (!attrs.Any(ad => ad.AttributeClass.MetadataName.ToUpperInvariant() 
                                == typeof(RequireBaseMethodCallAttribute).Name.ToUpperInvariant()))
            {
                return;
            }
            
            var overridenMethodName = overridenMethod.Name.ToString();
            string methodName = overridenMethodName;
            var invocations = mds.DescendantNodes().OfType<MemberAccessExpressionSyntax>().ToList();
            foreach (var inv in invocations)
            {
                var expr = inv.Expression;
                if ((SyntaxKind)expr.RawKind == SyntaxKind.BaseExpression)
                {
                    var memberAccessExpr = expr.Parent as MemberAccessExpressionSyntax;
                    if (memberAccessExpr == null)
                    {
                        continue;
                    }
                    // compare exprSymbol and overridenMethod
                    var exprMethodName = memberAccessExpr.Name.ToString();
                    if (exprMethodName != overridenMethodName)
                    {
                        continue;
                    }
                    var invokationExpr = memberAccessExpr.Parent as InvocationExpressionSyntax;
                    if (invokationExpr == null)
                    {
                        continue;
                    }
                    var exprMethodArgs = invokationExpr.ArgumentList.Arguments.ToList();
                    var ovrMethodParams = overridenMethod.Parameters.ToList();
                    if (exprMethodArgs.Count != ovrMethodParams.Count)
                    {
                        continue;
                    }
                    var paramMismatch = false;
                    for (int i = 0; i < exprMethodArgs.Count; i++)
                    {
                        var arg = exprMethodArgs[i];
                        var argType = context.SemanticModel.GetTypeInfo(arg.Expression);
                        var param = arg.NameColon != null ? 
                                    ovrMethodParams.FirstOrDefault(p => p.Name.ToString() == arg.NameColon.Name.ToString()) : 
                                    ovrMethodParams[i];
                        if (param == null || argType.Type != param.Type)
                        {
                            paramMismatch = true;
                            break;
                        }
                        exprMethodArgs.Remove(arg);
                        ovrMethodParams.Remove(param);
                        i--;
                    }
                    // If there are any parameters left without default value
                    // then it is not the base method overload we are looking for
                    if (ovrMethodParams.Any(p => p.HasExplicitDefaultValue))
                    {
                        continue;
                    }
                    if (!paramMismatch)
                    {
                        // If the actual arguments match with the method params
                        // then the base method invokation was found
                        // and there is no need to continue the search
                        return;
                    }
                }
            }
            
            var diag = Diagnostic.Create(Rule, mds.GetLocation(), methodName);
            context.ReportDiagnostic(diag);
        }
    }
