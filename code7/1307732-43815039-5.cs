    var firstCode =
    @"
        // First comment.
        // Second comment.
        int x(int a)
        {
            // This is a comment.
            // And this as well.
            if (a == 1) // This also
            {
                return 0 ;
            }
            
            /*
                Multi line comment.
            */if(a == -5) return -10   ;
        
            if (a == 2)
                    return 0 ;
                
            return 5;
                
        }
    ";
    var secondCode =
    @"
        // First comment.
        
        // Second comment.
        
        int x(int a)
        {
        
            // This is a comment.
            // And this as well.
                    if    (a 
                    == 1) // This also
            {
                return     0 ;
                  }
            
            /*
                Multi line comment.
            */
            
            if(a == -5) return -10   ;
        
            if (a == 2) return 0 ;
                
            return 5;
                
                
        }
    ";
    
    var firstMethod = CSharpSyntaxTree.ParseText(firstCode).GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().First();
    var secondMethod = CSharpSyntaxTree.ParseText(secondCode).GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().First();
    Console.WriteLine($"{firstMethod.IsEquivalentTo(secondMethod)}"); // Prints false.
    Console.WriteLine($"{firstMethod.IsEquivalentToWithCommentsPreserved(secondMethod)}"); // Prints true.
