       public override void VisitClassDeclaration(ClassDeclarationSyntax node)
            {
    [...]
                base.VisitClassDeclaration(node); // this was missing
            }
