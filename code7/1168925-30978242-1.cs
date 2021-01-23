    private bool IsCommand(IDeclaredElement declaredElement)
    {
        IClass theClass = declaredElement as IClass;          
        if (theClass !=null)
        {
            foreach (var psiModule in declaredElement.GetPsiServices().Modules.GetModules())
            {
                IDeclaredType commandInterfaceType = TypeFactory.CreateTypeByCLRName("HandlerNavigationTest.ICommand", psiModule, theClass.ResolveContext);
                var typeElement = commandInterfaceType.GetTypeElement();
                if (typeElement != null)
                {
                    var isDescendantOf = theClass.IsDescendantOf(typeElement);
                    return isDescendantOf;
                }
            }                
            
        }
        return false;
    }
