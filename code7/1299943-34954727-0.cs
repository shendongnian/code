    using System;
    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Infrastructure;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace EF7InMemoryBug
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Program p = new Program();
                MembershipContext m1 = p.GetNewContext();
                MembershipContext m2 = p.GetNewContext();
    
                foreach (var member in m1.Members)
                {
                    Console.WriteLine(member);
                }
    
                foreach (var member in m2.Members)
                {
                    Console.WriteLine(member);
                }
            }
    
            private MembershipContext GetNewContext()
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection
                    .AddEntityFramework()
                    .AddInMemoryDatabase()
                    .AddDbContext<MembershipContext>(c => c.UseInMemoryDatabase());
    
                MembershipContext context = serviceCollection.BuildServiceProvider().GetService<MembershipContext>();
    
                Member member1 = new Member()
                {
                    MemberId = 1,
                    FirstName = "James",
                    LastName = "Jones"
                };
    
                context.Members.Add(member1);
                context.SaveChanges();
                return context;
            }
    
        }
    
        public class Member
        {
            public int MemberId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
    
            public override string ToString()
            {
                return $"{MemberId} {FirstName} {LastName}";
            }
        }
    
        public class MembershipContext : DbContext
        {
            public MembershipContext(DbContextOptions options)
            : base(options) {}
            public DbSet<Member> Members { get; set; }
        }
    }
