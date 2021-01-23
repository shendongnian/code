    class ClassVirtualizationVisitor : CSharpSyntaxRewriter
    {	
    	List<string> classes = new List<String>();
    
    	public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                node =  (ClassDeclarationSyntax) base.VisitClassDeclaration(node);
    
    			string className = node.Identifier.ValueText;
    			classes.Add(className); // save your visited classes
    			
    			return node;
            }
    }
