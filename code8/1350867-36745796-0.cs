    public override object Execute(Expression expression)
            {
                var translatedExpression = Translate(expression);
                SetAdminSecurityToken();
    
                var elementType = GetElementType(expression);
    
                var task = GetResultFrom(elementType, translatedExpression);
                var resultProperty = typeof(Task<>).MakeGenericType(elementType).GetProperty("Result"); 
                var result = resultProperty.GetValue(task);
    
                return GetReturnValue(result, elementType);
            }
        private Type GetElementType(Expression expression)
        {
            var elementType = TypeSystem.GetElementType(expression.Type);
            //The IsMultipleResults property on the translator encapsulates the
            //logic mentioned in the answer description.
            return _queryTranslator.IsMultipleResults ? typeof(IEnumerable<>).MakeGenericType(elementType) : elementType;
        }
    
            private Task GetResultFrom(Type elementType, string translatedExpression)
            {
                var securityToken = _queryTranslator.UseUserToken
                    ? GetSecurityToken(_queryTranslator.UserEmail, _queryTranslator.UserPassword)
                    : _securityToken;
    
                var method = _httpRequest.GetType().GetMethod("GetHttpRequest").MakeGenericMethod(new[] { elementType });
                var task = (Task)method.Invoke(_httpRequest, new object[] { translatedExpression, securityToken, null });
                
                return task;
            }
