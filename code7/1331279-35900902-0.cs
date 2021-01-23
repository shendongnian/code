    public static class ValidateUtils
    {
    	static readonly Dictionary<Type, Dictionary<string, Delegate>> typeMemberFuncCache = new Dictionary<Type, Dictionary<string, Delegate>>();
    
    	public static P ValidateProperty<T, P>(this T obj, Expression<Func<T, P>> member, List<ValidationResult> results, Func<P, P> onValidCallback = null)
    		where T : class
    		where P : class
    	{
    		var memberInfo = ((MemberExpression)member.Body).Member;
    		var memberName = memberInfo.Name;
    		Func<T, P> memberFunc;
    		lock (typeMemberFuncCache)
    		{
    			var type = typeof(T);
    			Dictionary<string, Delegate> memberFuncCache;
    			if (!typeMemberFuncCache.TryGetValue(type, out memberFuncCache))
    				typeMemberFuncCache.Add(type, memberFuncCache = new Dictionary<string, Delegate>());
    			Delegate entry;
    			if (memberFuncCache.TryGetValue(memberName, out entry))
    				memberFunc = (Func<T, P>)entry;
    			else
    				memberFuncCache.Add(memberName, memberFunc = member.Compile());
    		}
    		var value = memberFunc(obj);
    		bool isValid = Validator.TryValidateProperty(value, new ValidationContext(obj) { MemberName = memberName }, results);
    		return isValid ? (onValidCallback != null ? onValidCallback(value) : value) : null;
    	}
    }
