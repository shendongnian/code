    private void checkParensButton_Click(object sender, EventArgs e)
    {
      // clean up previous selection
      mathEquation.SelectAll();
      mathEquation.SelectionBackColor = Color.White;
      var indexes = EnumerateUnbalancedParentheses(mathEquation.Text);
      foreach (var index in indexes)
      {
        mathEquation.Select(index, 1);
        mathEquation.SelectionBackColor = Color.Aqua;
      }
    }
    private static IEnumerable<int> EnumerateUnbalancedParentheses(string expression)
    {
      var openingParentheses = new Stack<int>();
      var closingParentheses = new Stack<int>();
      for (var i = 0; i < expression.Length; ++i)
      {
        var symbol = expression[i];
        if (symbol == '(')
        {
          openingParentheses.Push(i);
        }
        else if (symbol == ')')
        {
          if (openingParentheses.Count > 0)
            openingParentheses.Pop();
          else
            closingParentheses.Push(i);
        }
      }
      return openingParentheses.Concat(closingParentheses);
    }
