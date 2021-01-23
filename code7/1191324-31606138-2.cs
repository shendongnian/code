	var voidObject = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(void));
	var voidObject2 = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(void));
	Console.WriteLine("Type: {0}", voidObject.GetType());
	Console.WriteLine("IsValueType: {0}", voidObject.GetType().IsValueType);
	
	Console.WriteLine("Equals: {0}", voidObject.Equals(voidObject2));
	Console.WriteLine("GetHashCode1: {0}", voidObject.GetHashCode());
	Console.WriteLine("GetHashCode2: {0}", voidObject2.GetHashCode());
	Console.WriteLine("ToString: {0}", voidObject.ToString());
