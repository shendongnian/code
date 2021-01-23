    class ObjectToBeValidated {
       public string Name { get; set; }
       public int Age { get; set; }
    }
    class Validation {
        private List<Expression<Func<ObjectToBeValidated, string>>> requiredExpressions;
        public void AddRequired(Expression<Func<ObjectToBeValidated, string>> expression)
        {
            requiredExpressions.Add(expression);
        }
        private List<Expression<Func<ObjectToBeValidated, bool>>> rangeExpressions;
        public void AddRange(Expression<Func<ObjectToBeValidated, int>> expression, int min, int max)
        {
            Expression<Func<ObjectToBeValidated, bool>> checkRange = (p => expression.Compile().Invoke(p) >= min && expression.Compile().Invoke(p) < max);
            rangeExpressions.Add(checkRange);
        }
    }
