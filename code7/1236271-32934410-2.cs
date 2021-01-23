    class ObjectVisitor : IVisitor {
        private StringBuilder sb = new StringBuilder();
    
        public void VisitAnd(Object obj) {
            sb.Append("(");
            var and = "";
            foreach (var child in obj.Children) {
                sb.Append(and);
                child.AsVisitable().Accept(this);
                and = "and";
            }
            sb.Append(")");
        }
    
        public void VisitEquals(Object obj) {
            // Assuming equal object must have exactly one child 
            // Which again is a sign that visitor pattern is not bla bla...
            sb.Append("(")
              .Append(obj.Children[0].Name);
              .Append(" Equals ");
              .Append(obj.Children[0].Value);
              .Append(")");
        }
    }
