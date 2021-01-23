    public class VisitedType
    {
        public void Accept(IVisitor visitor)
        {
            var context = new VisitContext{ Visited = this };
            visitor.Visit(context);
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
        }
    
        protected void AcceptAsLeft(VisitContext context)
        {
            context.IsLeftNode=true;
            context.IsRightNode=false;
            visitor.Visit(context);
            
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
        }
        protected void AcceptAsRight(VisitContext context)
        {
            context.IsLeftNode=false;
            context.IsRightNode=true;
            visitor.Visit(context);
            
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
        }
    }
