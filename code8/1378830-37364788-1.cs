    public class CSharp6FeaturiesWalker : CSharpSyntaxWalker
    {
        public bool CSharp6Featuries { get; private set; }
    
        public CSharp6FeatureWalker()
        {
        }
    
        public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            if (node.ExpressionBody != null)
            {
                CSharp6Featuries = true;
            }
            else if (node.Initializer != null)
            {
                CSharp6Featuries = true;
            }
            base.VisitPropertyDeclaration(node);
        }
    
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (node.ExpressionBody != null)
            {
                CSharp6Featuries = true;
            }
            base.VisitMethodDeclaration(node);
        }
    
        public override void VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            if (node.ExpressionBody != null)
            {
                CSharp6Featuries = true;
            }
            base.VisitOperatorDeclaration(node);
        }
    
        public override void VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            if (node.ExpressionBody != null)
            {
                CSharp6Featuries = true;
            }
            base.VisitConversionOperatorDeclaration(node);
        }
    
        public override void VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            if (node.ExpressionBody != null)
            {
                CSharp6Featuries = true;
            }
            base.VisitIndexerDeclaration(node);
        }
    
        public override void VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            CSharp6Featuries = true;
            base.VisitConditionalAccessExpression(node);
        }
    
        public override void VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            CSharp6Featuries = true;
            base.VisitInterpolatedStringExpression(node);
        }
    
        public override void VisitCatchFilterClause(CatchFilterClauseSyntax node)
        {
            CSharp6Featuries = true;
            base.VisitCatchFilterClause(node);
        }
    }
