    public static class BusinessObjectExtensions
    {
        public static bool CanDoStuff(this BusinessObject obj, IRepository repository)
        {
            var args = new EArgument { Name = obj.Name };
            return repository.AMethod(obj.UserName, args);
        }
    }
