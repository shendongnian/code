    class Visitor : ExpressionVisitor {
        protected override Expression VisitBinary(BinaryExpression node) {
            // SomeOtherObjectId == "someId"
            if (node.NodeType == ExpressionType.Equal) {
                foreach (var child in new[] {node.Left, node.Right}) {
                    var memberEx = child as MemberExpression;
                    if (memberEx != null && memberEx.Member.Name == "SomeOtherObjectId") {
                        // return True constant
                        return Expression.Constant(true);
                    }
                }
            }
            return base.VisitBinary(node);
        }        
    }
