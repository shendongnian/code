		static public T CreateDelegate<T>(this ConstructorInfo constructor)
			where T: class
		{
			Validator.IsNotNull(constructor, "constructor");
			EquatableKey<Type, ConstructorInfo> key = new EquatableKey<Type, ConstructorInfo>(
				typeof(T),
				constructor);
			return (T)(object)_ConstructorDelegates.GetValue(key, () =>
			{
				Validator.IsAssignable<Delegate>(typeof(T), "T");
				Type delegateType = typeof(T);
				// Validate the delegate return type
				MethodInfo invoke = delegateType.GetMethod("Invoke");
				Validator.IsTrue(invoke.ReturnType.IsAssignableFrom(constructor.DeclaringType), "The return type of the delegate must match the declaring type of the constructor.");
				// Validate the signatures
				ParameterInfo[] delParams = invoke.GetParameters();
				ParameterInfo[] constructorParam = constructor.GetParameters();
				Validator.IsTrue(delParams.Length == constructorParam.Length, "The delegate signature does not match the signature of the constructor");
				for(int i = 0; i < delParams.Length; i++)
					if (delParams[i].ParameterType != constructorParam[i].ParameterType || delParams[i].IsOut) // Probably other things we should check ??
						throw new ValidationException("The delegate signature does not match the signature of the constructor");
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
				return method.CreateDelegate(delegateType);
			});
		}
