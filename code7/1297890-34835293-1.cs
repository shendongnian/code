    public static void Execute()
    {
    	var code =
    @"class XYZ
    {
      public int x => 4;                                  //HasBacking field : false IsReadOnly
    
      public int m { get { return 0;}}                    //HasBacking field : false IsReadOnly     
    
      public int y { get; set; }                          //HasBacking field : false Null body for setter or getter
    
      public int z { get { return 0; } set { } }          //HasBacking field : false Empty body for setter or getter
    
      private int _g;
      public int g                                        //HasBacking field : true Getter and Setter has no empty Bodies
       {
           get { return _g; }
           set { _g = value; }
       }
    }";
    
    	var tree = CSharpSyntaxTree.ParseText(code);
    	var root = tree.GetRoot();
    
    	foreach (var prop in root.DescendantNodes().OfType<PropertyDeclarationSyntax>())
    	{
    		Console.WriteLine(prop.HasBackingField());
    	}
    }
        }
    
    internal static class Extensions
    {
    	internal static bool HasBackingField(this PropertyDeclarationSyntax property)
    	{
    		var getter = property.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.GetAccessorDeclaration));
    		var setter = property.AccessorList?.Accessors.FirstOrDefault(x => x.IsKind(SyntaxKind.SetAccessorDeclaration));
    
    		if (setter?.Body == null || getter?.Body == null)
    		{
    			return false;
    		}
    
    		bool setterHasBodyStatements = setter.Body.Statements.Any();
    		bool getterHasBodyStatements = getter.Body.Statements.Any();
    
    		return setterHasBodyStatements && getterHasBodyStatements;
    	}
    }
