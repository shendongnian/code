    public static class ExtensionListEmail
    {
        public static IList<Email<string, string>> ToMyList(this IList<Email> list)
        {
            return new List<Email<string, string>>(list);
        }
        public static CollectionBase<Email<string, string>> ToMyCollection(this CollectionBase<Email> collection)
        {
            return new Emails(collection);
        }
    }
