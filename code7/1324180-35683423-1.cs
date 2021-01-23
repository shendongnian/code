    static Expression ReplaceMemberAssignment(this Expression expression, MemberInfo member, Expression value)
    {
    	return new MemberAssignmentReplacer { Member = member, Value = value }.Visit(expression);
    }
    
    class MemberAssignmentReplacer : ExpressionVisitor
    {
    	public MemberInfo Member;
    	public Expression Value;
    	protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
    	{
    		return node.Member == Member ? node.Update(Value) : base.VisitMemberAssignment(node);
    	}
    }
