    public class DateTimeOffsetResolver : ValueResolver<string, DateTimeOffset>
        {
            private DatabaseLoadRepository loadRepository;
            public personIdResolver(DatabaseLoadRepository repo)
            {
                this.loadRepository = repo;
            }
            protected override DateTimeOffset ResolveCore(string timeZone)
            {
                //Your logic for converting string into dateTimeOffset goes here
                return DateTimeOffset; //return the DateTimeOffset instance
            }
        }
