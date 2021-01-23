    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TestAnalyzer : DiagnosticAnalyzer
    {
        public override void Initialize(AnalysisContext context)
        {
            var solutionPath = (context.Options as WorkspaceAnalyzerOptions).Workspace.CurrentSolution.FilePath;
        }
    }
