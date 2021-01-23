    public class NameAndEmailResolver : ValueResolver<SomeObjectModel, string>
    {
        protected override string ResolveCore(SomeObjectModel source)
        {
            // need a quick and dirty list so we can perform linq query to isolate properties and return an anonymous type
            var list = new List<SomeObjectModel>(){source};
            return JsonConvert.SerializeObject(list.Select(x => new{x.Name, x.Emails});
        }
    }
