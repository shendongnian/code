		public class RegisterAllConcreteTypesAgainstAllInterfaces : IRegistrationConvention
		{
			public void Process(Type type, Registry registry) {
				if (type.IsAbstract || type.IsInterface || type.IsOpenGeneric())
					return;
				foreach(var i in type.GetInterfaces();
				    registry.For(i).Use(type);
			}
		}
