    class LoggedExpression : Expression {
      private Expression child;
      public LoggedExpression(Expression child) { ... }
      public string ToString() { return child.ToString(); }
      public bool Interpret() {
        bool result = child.Interpret();
        log("Executing rule: " + child + " --> " + result);
        return result;
      }
    }
