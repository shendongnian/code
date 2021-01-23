    static void Main(string[] args)
    {
    	ActionManager actionManager = new ActionManager();
        List<SomeInterface> listA = actionManager.CreateList<SomeInterface>(
                () => new Do_A(), () => new Do_B());
        List<SomeInterface> listB = actionManager.CreateList<SomeInterface>(
                () => new Do_A(), () => new Do_B());
    }
    public class ActionManager
    {
        private Dictionary<Type, SomeInterface> instantiatedActions = 
                new Dictionary<Type, SomeInterface>();
        public List<SomeInterface> CreateList<T>(params Expression<Func<T>>[] actions)
        {
            List<SomeInterface> theList = new List<SomeInterface>();
            foreach (var action in actions)
            {
				var type = GetObjectType<T>(action);
                if(!instantiatedActions.ContainsKey(type))
                {
                    instantiatedActions.Add(type, (SomeInterface)action.Compile().Invoke());
                }
                theList.Add(instantiatedActions[type]);
            }
            return theList;
        }
		
		private static Type GetObjectType<T>(Expression<Func<T>> expr)
		{
    		if ((expr.Body.NodeType == ExpressionType.Convert) ||
        		(expr.Body.NodeType == ExpressionType.ConvertChecked))
    		{
        		var unary = expr.Body as UnaryExpression;
        		if (unary != null)
            		return unary.Operand.Type;
    		}
    		return expr.Body.Type;
		}
    }
