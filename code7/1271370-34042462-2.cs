    class LoggingExpressionInterpreter : ExpressionInterpreter {
      ...
      public bool Visit(Expression.Or ast) {
        bool result = base.Visit(ast);
        log("Executing rule: " + child + " --> " + result);
        return result;
      }
    }
