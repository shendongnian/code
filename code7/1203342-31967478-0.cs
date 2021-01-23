    Expression leftExpr, rightExpr;
    var x = Expression.Parameter(t);
    if (left_element.All(char.IsDigit)) 
    {
        leftExpr = Expression.Constant(int.Parse(left_element));
    }
    else
    {
        leftExpr = Expression.PropertyOrField(x, left_element);
    }
    if (right_element.All(char.IsDigit)) 
    {
        rightExpr = Expression.Constant(int.Parse(right_element));
    }
    else
    {
        rightExpr = Expression.PropertyOrField(x, right_element);
    }
