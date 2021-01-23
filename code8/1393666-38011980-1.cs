    private static void AnalyseInvocation(SyntaxNodeAnalysisContext context)
	{
		var invocation = (InvocationExpressionSyntax)context.Node;
		var memberAccess = invocation.Expression as MemberAccessExpressionSyntax;
		if ((memberAccess == null) || (memberAccess.Name.Identifier.ValueText != "ExecuteReader"))
			return;
		if (memberAccess.Expression is IdentifierNameSyntax)
		{
			// The target is a simple identifier, the code being analysed is of the form
			// "command.ExecuteReader()" and memberAccess.Expression is the "command"
			// node
		}
		else if (memberAccess.Expression is InvocationExpressionSyntax)
		{
			// The target is another invocation, the code being analysed is of the form
			// "GetCommand().ExecuteReader()" and memberAccess.Expression is the
			// "GetCommand()" node
		}
		else if (memberAccess.Expression is MemberAccessExpressionSyntax)
		{
			// The target is a member access, the code being analysed is of the form
			// "x.Command.ExecuteReader()" and memberAccess.Expression is the "x.Command"
			// node
		}
	}
