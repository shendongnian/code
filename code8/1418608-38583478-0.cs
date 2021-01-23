    string str = "4 == 5 || 3 == 6 || 2 == 1";
    var stack = new Stack<string>();
    var elements = str.Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries);
    
    bool? expressionResult = null;
    foreach (var item in elements)
    {
        if(item == "||" || item == "&&")
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
            else if(item == "||")
            {
                expressionResult = expressionResult.Value || localResult;
            }
            else if (item == "&&")
            {
                expressionResult = expressionResult.Value || localResult;
            }
        }
    
        stack.Push(item);
    }
    Console.WriteLine(str + " Evaluates to: " + expressionResult.Value);
