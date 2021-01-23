    private void GotToInheritor(ISolution solution, IDeclaredElement declaredElement)   
    {
        IClass theClass = declaredElement as IClass;
        ITypeElement originalTypeElement= declaredElement as ITypeElement;
        foreach (var psiModule in declaredElement.GetPsiServices().Modules.GetModules())
        {
            IDeclaredType originalType = TypeFactory.CreateTypeByCLRName(theClass.GetClrName(), psiModule, theClass.ResolveContext);
            
            originalTypeElement = originalType.GetTypeElement();
            if (originalTypeElement != null)
            {
                break;
            }
        }
        var inheritorsConsumer = new InheritorsConsumer();
        SearchDomainFactory searchDomainFactory = solution.GetComponent<SearchDomainFactory>();
        
        foreach (var psiModule in declaredElement.GetPsiServices().Modules.GetModules())
        {
            IDeclaredType genericType = TypeFactory.CreateTypeByCLRName("HandlerNavigationTest.ICommandHandler`1", psiModule, theClass.ResolveContext);
            var genericTypeElement = genericType.GetTypeElement();
            if (genericTypeElement != null)
            {                    
                var theType = TypeFactory.CreateType(originalTypeElement);
                genericType.GetSubstitution().Apply(theType);
                var commandHandlerType = TypeFactory.CreateType(genericTypeElement,theType);
                var handlerTypeelement = commandHandlerType.GetTypeElement();
                solution.GetPsiServices().Finder.FindInheritors(handlerTypeelement, searchDomainFactory.CreateSearchDomain(solution, true),
                inheritorsConsumer, NullProgressIndicator.Instance);
                var inheritedInstance= inheritorsConsumer.FoundElements.First();
                var sourceFile = inheritedInstance.GetSourceFiles().First();
                
            }
        }   
    }
