		public static void PreBindModel(Controller controller, ViewModelBase viewModel, string operationName)
		{
			MethodInfo[] methods = controller.GetType().GetMethods();
			foreach (MethodInfo currentMethod in methods)
			{
				if (currentMethod.Name.Equals(operationName))
				{
					bool foundParamAttribute = false;
					foreach (ParameterInfo paramToAction in currentMethod.GetParameters())
					{
						object[] attributes = paramToAction.GetCustomAttributes(true);
						foreach (object currentAttribute in attributes)
						{
							BindAttribute bindAttribute = currentAttribute as BindAttribute;
							if (bindAttribute == null)
								continue;
							PropertyInfo[] allProperties = viewModel.GetType().GetProperties();
							IEnumerable<PropertyInfo> propertiesToReset =
								allProperties.Where(x => bindAttribute.IsPropertyAllowed(x.Name) == false);
							foreach (PropertyInfo propertyToReset in propertiesToReset)
							{
								propertyToReset.SetValue(viewModel, null);
							}
							foundParamAttribute = true;
						}
					}
					if (foundParamAttribute)
						return;
				}
			}
		}
