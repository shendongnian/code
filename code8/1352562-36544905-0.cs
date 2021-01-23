    var infoAttributes = CSharpSyntaxTree.ParseText(@"
    namespace MyNamespace
    {
      public class SomeClass
      {
        const string SomeConstant = ""Hi!"";
      
        [Info(""Some book"", ""Ray Brandenburg"", ""5.2.5"", ResourceId = 819)]
        public void SomeMethod()
        {
          
        }
        
        [InfoAttribute(SomeConstant, 42, ""Banana"")]
        pubic void SomeMethod2()
        {
          
        }
        
        // [Info(""Not going to happen"", ""Hilary Clinton"", ""1.2.0"")]
        public void SomeMethod3()
        {
          
        }
      }
    }
    ")
    .GetRoot()
    .DescendantNodes()
    .OfType<AttributeSyntax>()
    .Where(i => i.Name.ToString() == "Info" || i.Name.ToString() == "InfoAttribute")
    .Where
    (
      i => 
        i.ArgumentList.Arguments.Count(j => j.NameEquals == null) == 3 
        && i.ArgumentList.Arguments[0].GetFirstToken().IsKind(SyntaxKind.StringLiteralToken)
        && i.ArgumentList.Arguments[1].GetFirstToken().IsKind(SyntaxKind.StringLiteralToken)
        && i.ArgumentList.Arguments[2].GetFirstToken().IsKind(SyntaxKind.StringLiteralToken)
    )
    .Select
    (
      i =>
      new 
      {
        Title = (string)i.ArgumentList.Arguments[0].GetFirstToken().Value,
        Author = (string)i.ArgumentList.Arguments[1].GetFirstToken().Value,
        Version = (string)i.ArgumentList.Arguments[2].GetFirstToken().Value,
        ResourceId = 
          i.ArgumentList.Arguments
           .Where(j => j.NameEquals != null && j.NameEquals.Name.ToString() == "ResourceId")
           .Select(j => j.ChildNodes().Skip(1).First().GetFirstToken().Value.ToString())
           .FirstOrDefault()
      }
    );
    
    infoAttributes.Dump();
