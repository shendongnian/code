        public void WhatDoesTheAnimalSay_WANTED(Expression<Func<object>> expression)
        {
            var variableValue = expression.Compile();
            var body = (MemberExpression)expression.Body;
            var variableName = body.Member.Name;
            MessageBox.Show("The "+ variableName + " says: " + variableValue());
    }
