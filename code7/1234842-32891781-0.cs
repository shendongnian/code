	using System;
	using System.Linq;
	using System.Reflection;
	
	public class GenericDefinitionBinder : Binder
	{
        public static readonly GenericDefinitionBinder Default = new GenericDefinitionBinder();
		public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers)
		{
			throw new NotImplementedException();
		}
		
		public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers)
		{
			return match.SingleOrDefault(m => MethodOkay(m, types));
		}
		
		private static bool MethodOkay(MethodBase method, Type[] types)
		{
			var pars = method.GetParameters();
			if(types.Length != pars.Length) return false;
			for(int i = 0; i < types.Length; i++)
			{
				var par = pars[i].ParameterType;
				if(!(par == types[i] || (par.IsGenericType && par.GetGenericTypeDefinition() == types[i])))
				{
					return false;
				}
			}
			return true;
		}
		
		public override void ReorderArgumentArray(ref object[] args, object state)
		{
			throw new NotImplementedException();
		}
		
		public override object ChangeType(object value, Type type, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
		
		public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, System.Globalization.CultureInfo culture, string[] names, out object state)
		{
			throw new NotImplementedException();
		}
		
		public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
