    private static bool? EvaluateBooleanExpression(string expression)
    {
        var stack = new Stack<string>();
        var elements = expression.Split(new string[] { " " }, 
                                                StringSplitOptions.RemoveEmptyEntries);
    
        bool? expressionResult = null;
        foreach (var item in elements)
        {
            if (item == "||" || item == "&&")
            {
                int v2 = Int32.Parse(stack.Pop());
                string op = stack.Pop();
                int v1 = Int32.Parse(stack.Pop());
                bool localResult = false;
                if (op == "==")
                    localResult = v1 == v2;
                else if (op == "!=")
                    localResult = v1 != v2;
    
                if (expressionResult == null)
                    expressionResult = localResult;
                else if (item == "||")
                {
                    expressionResult = expressionResult.Value || localResult;
                    // no need to check further if one result is true
                    if (expressionResult.Value)
                        break;
                }
                else if (item == "&&")
                {
                    expressionResult = expressionResult.Value || localResult;
                }
            }
    
            stack.Push(item);
        }
    
        return expressionResult;
    }
