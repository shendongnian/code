		public static T CreateDelegate<T>(this ConstructorInfo constructor)
			where T : class
		{
			if (constructor == null)
				throw new ArgumentNullException("constructor");
			Type delegateType = typeof(T);
			if (!typeof(Delegate).IsAssignableFrom(delegateType))
				throw new ArgumentException("Generic parameter <T> must be a delegate.");
			// Validate the delegate return type
			MethodInfo invoke = delegateType.GetMethod("Invoke");
			if (!invoke.ReturnType.IsAssignableFrom(constructor.DeclaringType))
				throw new ArgumentException("The return type of the delegate must match the declaring type of the constructor.");
			// Validate the signatures
			ParameterInfo[] delParams = invoke.GetParameters();
			ParameterInfo[] constructorParam = constructor.GetParameters();
			if (delParams.Length != constructorParam.Length)
				throw new ArgumentException("The delegate signature does not match the signature of the constructor");
			for(int i = 0; i < delParams.Length; i++)
				if (delParams[i].ParameterType != constructorParam[i].ParameterType || delParams[i].IsOut) // Probably other things we should check ??
					throw new ArgumentException("The delegate signature does not match the signature of the constructor");
			// Create the dynamic method
			DynamicMethod method = new DynamicMethod(
				constructor.DeclaringType.Name + "_" + Guid.NewGuid().ToString().Replace("-", ""),
				constructor.DeclaringType,
				Array.ConvertAll(constructorParam, p => p.ParameterType),
				true);
			// Create the il
			ILGenerator ilGenerator = method.GetILGenerator();
			for(int i = 0; i < constructorParam.Length; i++)
				ilGenerator.Ldarg(i);
			ilGenerator.Emit(OpCodes.Newobj, constructor);
			if (method.ReturnType.IsValueType)
				ilGenerator.Emit(OpCodes.Box);
			ilGenerator.Emit(OpCodes.Ret);
			// Return the delegate :)
			return (T)(object)method.CreateDelegate(delegateType);
		}
