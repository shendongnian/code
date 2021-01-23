    Type[] controllers = assembly.GetTypes().Where(x => x.BaseType == typeof(Controller)).ToArray();
    foreach (Type controller in controllers)
        {
            ConstructorInfo[] constructors = controller.GetConstructors();
                
            foreach (var constructor in constructors)
            {
                RegisterControllerConstructor(constructor,_MyDependecy,controller,factory);
            }
        }
    }
    private void RegisterControllerConstructor(ConstructorInfo constructor, MyDependecy _MyDependecy, Type controller, CustomControllerFactory factory)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            Type[] paraTypes = parameters.Select(p => p.ParameterType).ToArray();
            MethodInfo method =
                factory.GetType().GetMethod("RegisterFactoryMethod").MakeGenericMethod(controller);
            if (paraTypes.Length == 1 && paraTypes[0] == _MyDependecy.GetType())
            {
                var param = new object[1];
                Func<IController> action = () =>
                {
                    return Activator.CreateInstance(controller, _MyDependecy) as IController;
                };
                param[0] = action;
                method.Invoke(factory, param);
            }
        }
