    // the constant could be on either side
    var variableExpression = binaryExpression.Left;
    var constantExpression = binaryExpression.Right as ConstantExpression;
    var operatorType = binaryExpression.NodeType;
    if (constantExpression == null)
    {
        return null;
    }
                                                                               
                                                                               
                                                                               
                                                                               
