    public class AccountMap : ClassMap<Account>
    {
            public AccountMap()
            {
                LazyLoad();
                Id(c => c.Id).GeneratedBy.Assigned();
                Component(c => c.FullName, m =>
                {
                   m.Map(Reveal.Member<FullName>("_firstName")).Column("FirstName").Length(30).Not.Nullable();
                   m.Map(Reveal.Member<FullName>("_lastName")).Column("LastName").Length(40).Not.Nullable();
                });
                Component(c => c.Email, m => m.Map(Reveal.Member<Email>("_address")).Column("EmailAddress").Not.Nullable());
                
                
            }
    }
