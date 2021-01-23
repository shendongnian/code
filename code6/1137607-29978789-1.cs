    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    namespace testEf6 {
        class Program {
            static void Main(string[] args) {
                using (testEF ctx = new testEF()) {
                    C2 c2 = new C2 {
                        Name = "old name",
                        C1 = new C1 { }
                    };
                    ctx.C2s.Add(c2);
                    ctx.SaveChanges();
                }
                using (testEF ctx = new testEF()) {
                    C2 c2 = ctx.C2s.First();
                    c2.Name = "new name";
                    ctx.SaveChanges(); // exception here with the attribute ========
                }
            }
        }
        public class testEF : DbContext {
            public IDbSet<C2> C2s { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder) {
                //modelBuilder.Configurations.Add(new C2EFConfiguration());
            }
        }
        public class C2EFConfiguration : EntityTypeConfiguration<C2> {
            public C2EFConfiguration() {
                HasRequired(x => x.C1).WithMany(y => y.C2s);
            }
        }
        public class C1 {
            public int Id { get; set; }
            public virtual ICollection<C2> C2s { get; set; }
        }
        public class C2 {
            public int Id { get; set; }
            public String Name { get; set; }
            [Required] 
            public virtual C1 C1 { get; set; }
        }
    }
