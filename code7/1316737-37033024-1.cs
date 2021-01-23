     protected override void Analyze(SyntaxNodeAnalysisContext context)
        {
            NodeToAnalyze = context.Node;
            Method = context.Node as MethodDeclarationSyntax;
            // only public method should be checked
            if (!IsModifiersValid) return;
            //skipping If the project is not named Model or Domain 
            var project = DteExtensions.CurrentProjectName;
            if (new[] { "Domain", "Model" }.Contains(project) == false) return;
            var methodSymbol = context.SemanticModel.GetDeclaredSymbol(Method) as IMethodSymbol;
            var solutionPath = Utilities.DteExtensions.SolutionFullPath;
            var msWorkspace = Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenSolutionAsync(solutionPath).Result;
            // looking in all projects inside of one solution
            var allDocumentsInEntireSolution = solution.Projects.SelectMany(it => it.Documents);
            //skip rule when in entire solution we have web form project             
            if (allDocumentsInEntireSolution.Any(x => x.Name == "Default.aspx.cs")) return;
            //Looking for all references            
            var refrencesFound = FindAllMethodReferences(Method.GetName(), solution);
            if (refrencesFound.Count() ==0)
                ReportDiagnostic(context, Method);
            else
            {
                var xyx = refrencesFound.Count();
            }
        }
        
        IEnumerable<ReferenceLocation> FindAllMethodReferences(string methodName, Solution solution)
        {
            IMethodSymbol methodSymbol = null;
            bool found = false;
            foreach (var project in solution.Projects)
            {
                foreach (var document in project.Documents)
                {
                    var model = document.GetSemanticModelAsync().Result;
                    var methodInvocation = document.GetSyntaxRootAsync().Result;
                    try
                    {
                        var nodes = methodInvocation.DescendantNodes().OfType<InvocationExpressionSyntax>().Where(x => x.Expression.ToString().Contains(methodName));
                        foreach (var node in nodes)
                        {
                            if (node == null) continue;
                            var member = node?.Expression as MemberAccessExpressionSyntax;
                            if (member == null)
                                continue;
                            var name = member?.Name?.ToString();
                            if (name.IsEmpty()) continue;
                            if (name != methodName) continue;
                            methodSymbol = model.GetSymbolInfo(node).Symbol as IMethodSymbol;
                            found = true;
                            break;
                        }
                    }
                    catch (Exception exp)
                    {
                        // Swallow the exception of type cast. 
                        // Could be avoided by a better filtering on above linq.
                        continue;
                    }
                }
                if (found) break;
            }
            if (found == false) return Enumerable.Empty<ReferenceLocation>();
            if (methodSymbol == null) return Enumerable.Empty<ReferenceLocation>();
            var result = new List<ReferenceLocation>();
            var refrences = SymbolFinder.FindReferencesAsync(methodSymbol, solution).Result;
            foreach (var refernc in refrences)
            {
                foreach (var location in refernc.Locations)
                {
                    result.Add(location);
                }
            }
            return result;
        }
