    private BoundExpression BindNameofOperatorInternal(InvocationExpressionSyntax node, 
                                                       DiagnosticBag diagnostics)
    {
        CheckFeatureAvailability(node.GetLocation(), MessageID.IDS_FeatureNameof, diagnostics);
        var argument = node.ArgumentList.Arguments[0].Expression;
        string name = "";
        // We relax the instance-vs-static requirement for top-level member access expressions by creating a NameofBinder binder.
        var nameofBinder = new NameofBinder(argument, this);
        var boundArgument = nameofBinder.BindExpression(argument, diagnostics);
        if (!boundArgument.HasAnyErrors && CheckSyntaxForNameofArgument(argument, out name, diagnostics) && boundArgument.Kind == BoundKind.MethodGroup)
        {
            var methodGroup = (BoundMethodGroup)boundArgument;
            if (!methodGroup.TypeArgumentsOpt.IsDefaultOrEmpty)
            {
                // method group with type parameters not allowed
                diagnostics.Add(ErrorCode.ERR_NameofMethodGroupWithTypeParameters, argument.Location);
            }
            else
            {
                nameofBinder.EnsureNameofExpressionSymbols(methodGroup, diagnostics);
            }
        }
        return new BoundNameOfOperator(node, boundArgument, ConstantValue.Create(name), Compilation.GetSpecialType(SpecialType.System_String));
    }
