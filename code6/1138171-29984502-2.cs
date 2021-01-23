    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace testef6 {
        public class Program {
            public static void Main(String[] args) {
                String cs = "Data Source=ALIASTVALK;Initial Catalog=testEF6;Integrated Security=True;MultipleActiveResultSets=True";
                using (TestContext ctx = new TestContext(cs)) {
                    ctx.Set<E11>().Add(new E11 { V = "a", V1 ="a1"});
                    ctx.Set<E12>().Add(new E12 { V = "b", V2 = "b2" });
                    ctx.SaveChanges();
                }
                using (TestContext ctx = new TestContext(cs)) {
                    foreach (E1 e in ctx.Set<E1>()) {
                        Console.WriteLine("{0,3}:{1}", e.Id, e.V);
                    }
                }            
            }
        }
        public class E1 {    
            public Int32 Id { get; set; }
            public String V { get; set; }
        }
        public class E11 : E1 {
            public String V1 { get; set; }
        }
        public class E12 : E1 {
            public String V2 { get; set; }
        }
        public class E1EFConfiguration : EntityTypeConfiguration<E1> {
            public E1EFConfiguration()
                : base() {
                ToTable("tE1s", "dbo");
                Map<E11>(m => m.Requires("dis").HasValue("E11"));
                Map<E12>(m => m.Requires("dis").HasValue("E12"));
                Property(m => m.V).HasMaxLength(100);
            }
        }
        public class E11EFConfiguration : EntityTypeConfiguration<E11> {
            public E11EFConfiguration()
                : base() {
                Property(m => m.V1).HasMaxLength(150);
            }
        }
        public class E12EFConfiguration : EntityTypeConfiguration<E12> {
            public E12EFConfiguration()
                : base() {
                Property(m => m.V2).HasMaxLength(32);
            }
        }
        public class TestContext : DbContext {
            public TestContext(String cs) : base(cs) {
                Database.SetInitializer<TestContext>(new DropCreateDatabaseAlways<TestContext>());
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {          
                modelBuilder.Configurations.Add(new E1EFConfiguration());
                modelBuilder.Configurations.Add(new E11EFConfiguration());
                modelBuilder.Configurations.Add(new E12EFConfiguration());
                base.OnModelCreating(modelBuilder);
            }       
        }
    }
