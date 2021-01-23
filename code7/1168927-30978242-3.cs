    private static readonly List<HandlerMapping> HandlerMappings = new List<HandlerMapping>
	{
		new HandlerMapping("HandlerNavigationTest.ICommand", "HandlerNavigationTest.ICommandHandler`1", "HandlerNavigationTest"),
		new HandlerMapping("HandlerNavTest2.IEvent", "HandlerNavTest2.IEventHandler`1", "HandlerNavTest2")
	};
	public IEnumerable<ContextNavigation> CreateWorkflow(IDataContext dataContext)
	{
		ICollection<IDeclaredElement> declaredElements = dataContext.GetData(DataConstants.DECLARED_ELEMENTS);
		if (declaredElements != null && declaredElements.Any())
		{
			IDeclaredElement declaredElement = declaredElements.First();
			ISolution solution = dataContext.GetData(JetBrains.ProjectModel.DataContext.DataConstants.SOLUTION);
			ITypeElement handlerType = GetHandlerType(declaredElement);
			if (handlerType != null)
			{
				yield return new ContextNavigation("&Handler", null, NavigationActionGroup.Other, () => GoToInheritor(solution, declaredElement as IClass, dataContext, handlerType));
			}
		}
	}
	private static ITypeElement GetHandlerType(IDeclaredElement declaredElement)
	{
		var theClass = declaredElement as IClass;
		if (theClass != null)
		{
			foreach (IPsiModule psiModule in declaredElement.GetPsiServices().Modules.GetModules())
			{
				foreach (var handlerMapping in HandlerMappings)
				{
					IDeclaredType commandInterfaceType = TypeFactory.CreateTypeByCLRName(handlerMapping.HandledType, psiModule, theClass.ResolveContext);
					ITypeElement typeElement = commandInterfaceType.GetTypeElement();
					if (typeElement != null)
					{
						if (theClass.IsDescendantOf(typeElement))
						{
							IDeclaredType genericType = TypeFactory.CreateTypeByCLRName(handlerMapping.HandlerType, psiModule, theClass.ResolveContext);
							ITypeElement genericTypeElement = genericType.GetTypeElement();
							return genericTypeElement;
						}
					}
				}
				
			}
		}
		return null;
	}
	private static void GoToInheritor(ISolution solution, IClass theClass, IDataContext dataContext, ITypeElement genericHandlerType)
	{
		var inheritorsConsumer = new InheritorsConsumer();
		var searchDomainFactory = solution.GetComponent<SearchDomainFactory>();
		IDeclaredType theType = TypeFactory.CreateType(theClass);
		IDeclaredType commandHandlerType = TypeFactory.CreateType(genericHandlerType, theType);
		ITypeElement handlerTypeelement = commandHandlerType.GetTypeElement();
		solution.GetPsiServices().Finder.FindInheritors(handlerTypeelement, searchDomainFactory.CreateSearchDomain(solution, true),
			inheritorsConsumer, NullProgressIndicator.Instance);
		var potentialNavigationPoints = new List<INavigationPoint>();
		foreach (ITypeElement inheritedInstance in inheritorsConsumer.FoundElements)
		{
			IDeclaredType[] baseClasses = inheritedInstance.GetAllSuperTypes();
			foreach (IDeclaredType declaredType in baseClasses)
			{
				if (declaredType.IsInterfaceType())
				{
					if (declaredType.Equals(commandHandlerType))
					{
						var navigationPoint = new DeclaredElementNavigationPoint(inheritedInstance);
						potentialNavigationPoints.Add(navigationPoint);
					}
				}
			}
		}
		if (potentialNavigationPoints.Any())
		{
			NavigationOptions options = NavigationOptions.FromDataContext(dataContext, "Which handler do you want to navigate to?");
			NavigationManager.GetInstance(solution).Navigate(potentialNavigationPoints, options);
		}
	} 
    public class InheritorsConsumer : IFindResultConsumer<ITypeElement>
    {
        private const int MaxInheritors = 50;
        private readonly HashSet<ITypeElement> elements = new HashSet<ITypeElement>();
        public IEnumerable<ITypeElement> FoundElements
        {
            get { return elements; }
        } 
        public ITypeElement Build(FindResult result)
        {
            var inheritedElement = result as FindResultInheritedElement;
            if (inheritedElement != null)
                return (ITypeElement) inheritedElement.DeclaredElement;
            return null;
        }
        public FindExecution Merge(ITypeElement data)
        {
            elements.Add(data);
            return elements.Count < MaxInheritors ? FindExecution.Continue : FindExecution.Stop;
        }
    }
