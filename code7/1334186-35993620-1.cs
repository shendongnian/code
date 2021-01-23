    into Count =c.Members.OfType <MethodDeclarationSyntax>().Count();
    for  (int i=0;i <Count; i++)
    {
        List <MethodDeclarationSyntax > l=c.Members.OfType <MethodDeclarationSyntax>().ToList();
        MethodDeclarationSyntax NewMethod=GetNewMethod (l [i]);
        c=c.ReplaceNode(l [i],NewMethod);
    }
