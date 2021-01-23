    public class FieldToPropertyConverter: CSharpSyntaxRewriter
    {
     FieldToPropertyConverter(string YourSolutionFilePath)
    {
        OpenSolution( YourSolutionFilePath);
    }
    public void OpenSolution(string path)
    {
        // OPEN your solution here
    }
    public Solution s ;
    public void Convent()
    {
         foreach ( var p in s.Projects)
             foreach ( var d in p.Documents)
             {
                  var cus = Visit(d.GetSyntaxRootAsync().Result);
                  // save cus to solution
             }
             // save you set solution to your work space
    }
    public override SyntaxNode VisitFieldDeclarationSyntax( FieldDeclarationSyntax f)
    {
         PropertyDeclaractionSyntax p =SyntaxFactory.PropertyDeclaraction( f.Declaraction.Type, f.Declaraction.Variables.First().Identifier);
        return p;
    } 
    }
