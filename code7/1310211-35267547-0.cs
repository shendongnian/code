                    var nameClass = invocationExpersion.GetSingleAncestor<ClassDeclarationSyntax>().GetName();
                    var nameNameSpace = (invocationExpersion.GetSingleAncestor<NamespaceDeclarationSyntax>() as NamespaceDeclarationSyntax).Name;
                    var symbolMethod = context.SemanticModel.GetSymbolInfo(invocation).Symbol as IMethodSymbol;
                    if (symbolMethod == null) return;
                    if (symbolMethod.Parameters.Any()) return;
                    //--- method has several signature
                    if (symbolMethod.ContainingType.GetMembers().Count(it => it.Name == symbolMethod.Name) > 1) return;
                    if (symbolMethod.ContainingSymbol.Name == nameClass && nameNameSpace.ToString().Contains(symbolMethod.ContainingNamespace.Name))
                    {
                        if (symbolMethod.DeclaredAccessibility != Accessibility.Private && symbolMethod.Name.StartsWith("Calculate"))
                        {
                            ReportDiagnostic(context, symbolMethod.Locations.FirstOrDefault(), invocation.Identifier.ValueText);
                        }
                    }
