    public static TEntityId Parse(string val) {
    	var constr = typeof(TEntityId).GetConstructor(
            // Since the constructor is private, you need binding flags
            BindingFlags.Instance | BindingFlags.NonPublic
        ,   null
        ,   new[]{ typeof(string) }
        ,   null);
    	if (constr == null) {
    		throw new InvalidOperationException("No constructor");
    	}
        return (TEntityId)constr.Invoke(new object[] {val});
    }
