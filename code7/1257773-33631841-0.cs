    public class Grouping<TKey, TELement>
    {
        public TKey Key { get; set; }
        public IEnumerable<TELement> Elements { get; set; }
    }
    var result = context.Set<Person>()
        .GroupJoin(context.Set<Address>(), x => x.Id, x => x.PersonId,
            (person, addresses) => new Grouping<Person, Address>
            {
                Key = person,
                Elements = addresses.DefaultIfEmpty()
            });
