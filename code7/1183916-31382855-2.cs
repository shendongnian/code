    class ObjectToBeValidated {
       public string Name { get; set; }
       public int Age { get; set; }
    }
    class Validation {
        private List<Expression<Func<ObjectToBeValidated, bool>>> requiredExpressions;
        private List<Expression<Func<ObjectToBeValidated, bool>>> rangeExpressions;
        public void AddRequired(Expression<Func<ObjectToBeValidated, string>> expression)
        {
            Expression<Func<ObjectToBeValidated, bool>> checkRequired = (p => !string.IsNullOrEmpty(expression.Compile().Invoke(p)));
            requiredExpressions.Add(checkRequired);
        }
        
        public void AddRange(Expression<Func<ObjectToBeValidated, int>> expression, int min, int max)
        {
            Func<ObjectToBeValidated, int> compiledFunc = expression.Compile();
            Expression<Func<ObjectToBeValidated, bool>> checkRange = (p => compiledFunc.Invoke(p) >= min && compiledFunc.Invoke(p) < max);
            rangeExpressions.Add(checkRange);
        }
    }
