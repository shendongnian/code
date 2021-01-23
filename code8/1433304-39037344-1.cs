	// var declaredType = semanticModel.GetDeclaredSymbol(@catch.Declaration).Type;
    // ^^ only works on catch(FooException x), doesn't work on catch (FooException)	
	var declaredType = Model.GetTypeInfo(@catch.Declaration.Type);
    var implements = false;
	for (var i = declaredType.Type; i != null; i = i.BaseType)
	{
		if (i == exceptionType)
		{
			implements = true;
			break;
		}
	}
    // implements holds the result
        
