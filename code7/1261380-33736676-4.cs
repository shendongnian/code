    public class MyTypeResolver : JavaScriptTypeResolver
    {
        public override Type ResolveType(string id)
        {
            return typeof(MyTypeResolver).Assembly.GetTypes().First(t => t.Name == id);
        }
        public override string ResolveTypeId(Type type)
        {
            return type.Name;
        }
    }
