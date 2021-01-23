    void Main()
    {
    	List<string> stringlist = new List<string> { "a", "b", "c"};
    	List<int> intlist = new List<int> { 1, 2, 3};
    	string notList = "";
    	var expression = Expression.Call(typeof(Methods), "CastToList", new Type[] { stringlist.GetType(), stringlist.GetType().GetGenericArguments()[0]}, Expression.Constant(stringlist));
    	Expression.Lambda<Func<bool>>(expression).Compile()();
    	expression = Expression.Call(typeof(Methods), "CastToList", new Type[] { intlist.GetType(), intlist.GetType().GetGenericArguments()[0] }, Expression.Constant(intlist));
    	Expression.Lambda<Func<bool>>(expression).Compile()();
    	expression = Expression.Call(typeof(Methods), "CastToList", new Type[] { notList.GetType(), typeof(object) }, Expression.Constant(notList));
    	Expression.Lambda<Func<bool>>(expression).Compile()();
    }
    
    public static class Methods
    {
    	public static void MapListToField<T>(List<T> genericList) { }
    	public static bool CastToList<L, T>(L obj)
    	{
    		if (obj.GetType() == typeof(List<T>))
    		{
    			Console.Write("List contains objects of Type: {0}\n", typeof(T).ToString());
    			List<T> genericList = obj as List<T>;
    			MapListToField(genericList);
    			return true;
    		}
    		else
    		{
    			Console.Write("Not list, Type is: {0}\n", typeof(L).ToString());
    			return false;
    		}
    	}
    }
