	public class StaticWrapper : DynamicObject {
	  Type _type;
	  public StaticWrapper(Type type) {
		_type = type;
	  }
	  public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result) {
		var method = _type.GetMethod(binder.Name, BindingFlags.Static | BindingFlags.Public, null, args.Select(a => a.GetType()).ToArray(), null);
		if (method == null) return base.TryInvokeMember(binder, args, out result);
		result = method.Invoke(null, args);
		return true;
	  }
	  // also do properties ...
	}
	
