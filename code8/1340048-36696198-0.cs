    private static void AnalyzeSymbol(SymbolAnalysisContext context)
    {
      var members = namedTypeSymbol.GetMembers();
      var methods = from m in members
                    where (m.Kind == SymbolKind.Method && 
                      !m.IsImplicitlyDeclared && m.CanBeReferencedByName)
                    select m;
      var properties = from m in members
                       where m.Kind == SymbolKind.Property
                       select m;
      foreach (var p in properties)
      {
        foreach (var m in methods)
        {
          if (p.Locations.First().SourceSpan.Start > m.Locations.First().SourceSpan.Start)
          {
             // For all such symbols, produce a diagnostic.
             var diagnostic = Diagnostic.Create(Rule, m.Locations[0], m.Name);
             context.ReportDiagnostic(diagnostic);
          }
        }
      }
    }
