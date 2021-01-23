	var name = SyntaxFactory.ParseName("MyAttribute");
	var arguments = SyntaxFactory.ParseAttributeArgumentList("(\"some_param\")");
	var attribute = SyntaxFactory.Attribute(name, arguments); //MyAttribute("some_param")
	var attributeList = new SeparatedSyntaxList<AttributeSyntax>();
	attributeList = attributeList.Add(attribute);
	var list = SyntaxFactory.AttributeList(attributeList);   //[MyAttribute("some_param")]
