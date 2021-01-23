	public class PropertyBagSyntaxInterpreter<TKey>
	{
		private readonly SyntaxNode _root;
		public SyntaxElementContainer<TKey> Container { get; }
		protected PropertyBagSyntaxInterpreter(ImmutableDictionary<string, string> propertyBag, SyntaxNode root)
		{
			_root = root;
			Container = new SyntaxElementContainer<TKey>(propertyBag);
		}
		public PropertyBagSyntaxInterpreter(Diagnostic diagnostic, SyntaxNode root)
			: this(diagnostic.Properties, root)
		{
		}
		public SyntaxNode GetNode(TKey nodeKey)
		{
			return _root.FindNode(Container.GetTextSpanFromKey(nodeKey.ToString()));
		}
		public TSyntaxType GetNodeAs<TSyntaxType>(TKey nodeKey) where TSyntaxType : SyntaxNode
		{
			return _root.FindNode(Container.GetTextSpanFromKey(nodeKey.ToString())) as TSyntaxType;
		}
		public SyntaxToken GetToken(TKey tokenKey)
		{
			return _root.FindToken(Container.GetTextSpanStartFromKey(tokenKey.ToString()));
		}
		public SyntaxTrivia GetTrivia(TKey triviaKey)
		{
			return _root.FindTrivia(Container.GetTextSpanStartFromKey(triviaKey.ToString()));
		}
	}
