    public class VisitedType
    {
        public void Accept(IVisitor visitor)
        {
            var context = new VisitContext{ Visited = this, Lineage = new LinkedList<VisitedType>() };
			context.Lineage.AddLast(this);
            visitor.Visit(context);
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
        }
    
        protected void AcceptAsLeft(VisitContext context)
        {
			//add a bread crumb
			context.Lineage.AddLast(this);
            context.IsLeftNode=true;
            context.IsRightNode=false;
            visitor.Visit(context);
            
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
			
			//remove us when we've visited our children
			context.Lineage.RemoveLast();
        }
        protected void AcceptAsRight(VisitContext context)
        {
			//add a bread crumb
			context.Lineage.AddLast(this);
            context.IsLeftNode=false;
            context.IsRightNode=true;
            visitor.Visit(context);
            
            _leftNode.AcceptAsLeft(context);
            _rightNode.AcceptAsRight(context);
			//remove us when we've visited our children
			context.Lineage.RemoveLast();
        }
    }
