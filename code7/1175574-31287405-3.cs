	using T = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree;
	using F = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
	using K = Microsoft.CodeAnalysis.CSharp.SyntaxKind;
	public class DiscoverModulesCompileModule : ICompileModule
	{
		private static MethodInfo GetMetadataMethodInfo = typeof(PortableExecutableReference)
			.GetMethod("GetMetadata", BindingFlags.NonPublic | BindingFlags.Instance);
		private static FieldInfo CachedSymbolsFieldInfo = typeof(AssemblyMetadata)
			.GetField("CachedSymbols", BindingFlags.NonPublic | BindingFlags.Instance);
		private ConcurrentDictionary<MetadataReference, string[]> _cache
			= new ConcurrentDictionary<MetadataReference, string[]>();
		public void AfterCompile(IAfterCompileContext context) { }
		public void BeforeCompile(IBeforeCompileContext context)
		{
			// Firstly, I need to resolve the namespace of the ModuleProvider instance in this current compilation.
			string ns = GetModuleProviderNamespace(context.Compilation.SyntaxTrees);
			// Next, get all the available modules in assembly and compilation references.
			var modules = GetAvailableModules(context.Compilation).ToList();
			// Map them to a collection of statements
			var statements = modules.Select(m => F.ParseStatement("AddModule<" + module + ">();")).ToList();
			// Now, I'll create the dynamic implementation as a private class.
			var cu = F.CompilationUnit()
				.AddMembers(
					F.NamespaceDeclaration(F.IdentifierName(ns))
						.AddMembers(
							F.ClassDeclaration("ModuleProvider")
								.WithModifiers(F.TokenList(F.Token(K.PartialKeyword)))
								.AddMembers(
									F.MethodDeclaration(F.PredefinedType(F.Token(K.VoidKeyword)), "Setup")
										.WithModifiers(
											F.TokenList(
												F.Token(K.ProtectedKeyword), 
												F.Token(K.OverrideKeyword)))
										.WithBody(F.Block(statements))
								)
						)
				)
				.NormalizeWhitespace(indentation("\t"));
			var tree = T.Create(cu);
			context.Compilation = context.Compilation.AddSyntaxTrees(tree);
		}
		// Rest of implementation, described below
	}
