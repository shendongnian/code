    class DefaultReplacer : ExpressionVisitor {
        protected override Expression VisitGoto(GotoExpression g) {
            if (g.Kind != GotoExpressionKind.Return || g.Value == null) {
                return base.VisitGoto(g);
            }
            // If we are here, it's a return expression with Value.
            // Check if Value represents default(System.Void),
            // and return a replacement expression here
            return ...
        }
    }
