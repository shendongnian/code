    class BarExtractor : ExpressionVisitor {
        public Bar bar;
        protected override Expression VisitConstant(ConstantExpression node) {
            object closureObj = node.Value;
            if(closureObj != null && closureObj.GetType().Name.StartsWith("<>c__DisplayClass")) {
                var barField = closureObj.GetType().GetField("bar");
                if(barField != null && barField.FieldType == typeof(Bar))
                    bar = barField.GetValue(closureObj) as Bar;
            }
            return base.VisitConstant(node);
        }
    }
