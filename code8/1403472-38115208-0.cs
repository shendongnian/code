	using System;
	using System.Collections.Generic;
	namespace TestPropagationOfPropertyChanges
	{
		[AttributeUsage(AttributeTargets.All)]
		public class ListenForModelPropertyChangedAttribute : System.Attribute
		{
			public List<string> ModelPropertyNames = new List<string>();
			public ListenForModelPropertyChangedAttribute (string [] propertyNames)
			{
				ModelPropertyNames.AddRange (propertyNames);
			}
		}
	}
