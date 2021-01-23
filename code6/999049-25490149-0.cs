		var parser = new CSharpParser();
		SyntaxTree tree = parser.Parse(code);
		
		tree.AcceptVisitor(new MyVistor());
	class MyVistor : DepthFirstAstVisitor
	{
		public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			Console.WriteLine(methodDeclaration.Name);
			base.VisitMethodDeclaration(methodDeclaration);
		}
	}
