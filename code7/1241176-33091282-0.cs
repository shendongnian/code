            public bool SomeTriedDiagnosticMethod(SyntaxNodeAnalysisContext nodeContext)
        {
            var classDeclarationNode = nodeContext.Node as ClassDeclarationSyntax;
            if (classDeclarationNode == null) return false;
            var baseType = classDeclarationNode.BaseList.Types.FirstOrDefault(); //  Better use this in all situations to be sure code won't break
            var nameOfFirstBaseType = baseType.Type.ToString();  
            return nameOfFirstBaseType == "BaseType";
        }
