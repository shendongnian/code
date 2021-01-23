    [Serializable]
    public class FooAspect : LocationInterceptionAspect {
        public override void OnGetValue(LocationInterceptionArgs args) {
            var foo = ((Foo)args.Instance);
            if (foo.Properties == null || !foo.Properties.ContainsKey(args.LocationName))
                args.Value = null;
            else
                args.Value = foo.Properties[args.LocationName];
        }
        public override void OnSetValue(LocationInterceptionArgs args) {
            var foo = ((Foo) args.Instance);
            if (foo.Properties == null)
                foo.Properties = new Dictionary<string, object>();
            foo.Properties[args.LocationName] = args.Value;
        }
    }
