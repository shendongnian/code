    Token Exec(Stack<Token> operatorStack, Stack<Token> operandStack)
    {
        var op = operatorStack.Pop();
        var t1 = operandStack.Pop();
        var t2 = operandStack.Pop();
        switch (op.Value)
        {
            case "+": return new Token() { Value = (int.Parse(t1.Value) + int.Parse(t2.Value)).ToString(), Type = TokenType.Operand };
            case "-": return new Token() { Value = (int.Parse(t2.Value) - int.Parse(t1.Value)).ToString(), Type = TokenType.Operand };
            case "*": return new Token() { Value = (int.Parse(t1.Value) * int.Parse(t2.Value)).ToString(), Type = TokenType.Operand };
            case "/": return new Token() { Value = (int.Parse(t2.Value) / int.Parse(t1.Value)).ToString(), Type = TokenType.Operand };
        }
        return null;
    }
    int Eval(string input)
    {
        var tokens = Parse(input);
        var operatorStack = new Stack<Token>();
        var operandStack = new Stack<Token>();
        var precedence = new Dictionary<string, int>() { { "+", 0 }, { "-", 0 }, { "*", 1 }, { "/", 1 } };
        foreach (var token in tokens)
        {
            if (token.Type == TokenType.Operand) operandStack.Push(token);
            if (token.Type == TokenType.Operator)
            {
                while (operatorStack.Count > 0 && precedence[operatorStack.Peek().Value] >= precedence[token.Value])
                {
                    operandStack.Push(Exec(operatorStack, operandStack));
                }
                operatorStack.Push(token);
            }
        }
        while(operatorStack.Count>0)
        {
            operandStack.Push(Exec(operatorStack, operandStack));
        }
        return int.Parse(operandStack.Pop().Value);
    }
