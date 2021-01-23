        private static async Task<List<ReferencedSymbolLocation>> GetReferenceSymbolLocationsAsync(
            Solution solution,
            SemanticModel semanticModel,
            ReferenceLocation reference,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var syntaxTree = semanticModel.SyntaxTree;
            var position = reference.Location.SourceSpan.Start;
            var result = new List<ReferencedSymbolLocation>();
            if (position >= syntaxTree.Length)
            {
                return result;
            }
            var root = await syntaxTree.GetRootAsync(cancellationToken).ConfigureAwait(false);
            var foundNode = root.FindNode(reference.Location.SourceSpan, false, getInnermostNodeForTie: false);
            // Try and keep track of what kind of syntactical context
            // we found the referenced symbol:
            ReferenceType discoveredType = ReferenceType.Other;
            for (var current = foundNode; current != null; current = current.Parent)
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (current as BaseListSyntax != null)
                {
                    discoveredType = ReferenceType.BaseClass;
                    continue;
                }
                else if (current as ClassDeclarationSyntax != null)
                {
                    if (discoveredType == ReferenceType.Other)
                    {
                        discoveredType = ReferenceType.Class;
                    }
                    result.Add(CreateReferenceSymbolLocation(reference, semanticModel, current, discoveredType, cancellationToken));
                    break;
                }
                else if (current as PropertyDeclarationSyntax != null)
                {
                    result.Add(CreateReferenceSymbolLocation(reference, semanticModel, current, ReferenceType.Property, cancellationToken));
                    break;
                }
                else if (current as ParameterSyntax != null)
                {
                    // This covers method parameters and lambda parameters:
                    result.Add(CreateReferenceSymbolLocation(reference, semanticModel, current, ReferenceType.Parameter, cancellationToken));
                    break;
                }
                else if (current?.Parent as VariableDeclarationSyntax != null)
                {
                    var grandparent = current?.Parent?.Parent;
                    var parent = current.Parent as VariableDeclarationSyntax;
                    if (grandparent as LocalDeclarationStatementSyntax != null)
                    {
                        discoveredType = ReferenceType.LocalVariable;
                    }
                    // Ditto for field based things:
                    else if (grandparent as BaseFieldDeclarationSyntax != null)
                    {
                        if (grandparent as FieldDeclarationSyntax != null)
                        {
                            discoveredType = ReferenceType.Field;
                        }
                        else if (grandparent as EventFieldDeclarationSyntax != null)
                        {
                            discoveredType = ReferenceType.Event;
                        }
                    }
                    else if (grandparent as ForStatementSyntax != null)
                    {
                        discoveredType = ReferenceType.ForVariable;
                    }
                    else if (grandparent as FixedStatementSyntax != null)
                    {
                        discoveredType = ReferenceType.FixedVariable;
                    }
                    else if (grandparent as UsingStatementSyntax != null)
                    {
                        discoveredType = ReferenceType.UsingVariable;
                    }
                    foreach (var variable in parent.Variables)
                    {
                        result.Add(CreateReferenceSymbolLocation(reference, semanticModel, variable, discoveredType, cancellationToken));
                    }
                    break;
                }
                else if (current as InvocationExpressionSyntax != null)
                {
                    discoveredType = ReferenceType.MethodInvocation;
                    continue;
                }
                else if (current as ObjectCreationExpressionSyntax != null)
                {
                    // This covers constructing a class directly 'new XYZ()'
                    // and 'new Action<XYZ>()':
                    discoveredType = ReferenceType.ObjectCreation;
                    continue;
                }
                else if (current as MethodDeclarationSyntax != null)
                {
                    result.Add(CreateReferenceSymbolLocation(reference, semanticModel, current, discoveredType, cancellationToken));
                    break;
                }
            }
            return result;
        }
        private static ReferencedSymbolLocation CreateReferenceSymbolLocation(
            ReferenceLocation reference,
            SemanticModel semanticModel,
            SyntaxNode node,
            ReferenceType referenceType,
            CancellationToken cancellationToken)
        {
            return new ReferencedSymbolLocation(reference, semanticModel.GetDeclaredSymbol(node, cancellationToken), referenceType);
        }
        public enum ReferenceType
        {
            None = 0,
            /// <summary>
            /// Used for ReferenceSymbolLocations where the context of the reference
            /// isn't yet in this enumeration. ReferenceSymbolLocation.ReferencedSymbol will point at the
            /// declaration that contains the ReferenceLocation.
            /// </summary>
            Other,
            Class,
            BaseClass,
            Field,
            Property,
            Parameter,
            Event,
            LocalVariable,
            ForVariable,
            FixedVariable,
            UsingVariable,
            // The following are related to references found inside of statements:
            MethodInvocation,
            ObjectCreation,
        }
        public class ReferencedSymbolLocation
        {
            public ReferenceLocation ReferenceLocation { get; private set; }
            public ISymbol ReferencedSymbol { get; private set; }
            public ReferenceType ReferenceType { get; private set; }
            internal ReferencedSymbolLocation(ReferenceLocation location, ISymbol referencedSymbol, ReferenceType referenceType)
            {
                ReferenceLocation = location;
                ReferencedSymbol = referencedSymbol;
                ReferenceType = referenceType;
            }
        }
