    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Linq.Expressions;
    namespace SO24542133
    {
        public class AuditLog
        {
            public int Id { get; set; }
            public string TableName { get; set; }
            public int? EntityId { get; set; }
            public string Text { get; set; } 
        }
        public class SomeEntity
        {
            public int Id { get; set; }
            public string Something { get; set; }
        }
        internal class AuditLogConfiguration : EntityTypeConfiguration<AuditLog>
        {
            public AuditLogConfiguration()
            {
                ToTable("dbo.AuditLog");
                HasKey(x => x.Id);
                Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.TableName).HasColumnName("TableName").IsOptional().HasMaxLength(50);
                Property(x => x.EntityId).HasColumnName("EntityId").IsOptional();
                Property(x => x.Text).HasColumnName("Text").IsOptional();
            }
        }
        internal class SomeEntityConfiguration : EntityTypeConfiguration<SomeEntity>
        {
            public SomeEntityConfiguration()
            {
                ToTable("dbo.SomeEntity");
                HasKey(x => x.Id);
                Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.Something).HasColumnName("Something").IsOptional();
            }
        }
        public interface IMyDbContext : IDisposable
        {
            IDbSet<AuditLog> AuditLogSet { get; set; }
            IDbSet<SomeEntity> SomeEntitySet { get; set; }
            int SaveChanges();
        }
        public class MyDbContext : DbContext, IMyDbContext
        {
            public IDbSet<AuditLog> AuditLogSet { get; set; }
            public IDbSet<SomeEntity> SomeEntitySet { get; set; }
            static MyDbContext()
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
            }
            public MyDbContext(string connectionString) : base(connectionString)
            {
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations.Add(new AuditLogConfiguration());
                modelBuilder.Configurations.Add(new SomeEntityConfiguration());
            }
        }
        
        class Program
        {
            private static void CreateTestData(MyDbContext context)
            {
                SomeEntity e1 = new SomeEntity { Something = "bla" };
                SomeEntity e2 = new SomeEntity { Something = "another bla" };
                SomeEntity e3 = new SomeEntity { Something = "third bla" };
                context.SomeEntitySet.Add(e1);
                context.SomeEntitySet.Add(e2);
                context.SomeEntitySet.Add(e3);
                context.SaveChanges();
                AuditLog a1 = new AuditLog { EntityId = e1.Id, TableName = "SomeEntity", Text = "abc" };
                AuditLog a2 = new AuditLog { EntityId = e1.Id, TableName = "AnotherTable", Text = "def" };
                AuditLog a3 = new AuditLog { EntityId = e1.Id, TableName = "SomeEntity", Text = "ghi" };
                AuditLog a4 = new AuditLog { EntityId = e2.Id, TableName = "SomeEntity", Text = "jkl" };
                context.AuditLogSet.Add(a1);
                context.AuditLogSet.Add(a2);
                context.AuditLogSet.Add(a3);
                context.AuditLogSet.Add(a4);
                context.SaveChanges();
            }
            static IQueryable<dynamic> GetEntities<T>(IDbSet<T> entitySet, Expression<Func<T, IEnumerable<AuditLog>>> joinExpression) where T : class
            {
                var result = entitySet.SelectMany(joinExpression,(entity, auditLog) => new {entity, auditLog}); 
                return result.GroupBy(item => item.entity)
                    .Select(group => new 
                    {
                        Entity = group.Key,
                        Logs = group.Where(i => i.auditLog != null).Select(i => i.auditLog)
                    });            
            }
            static void Main()
            {
                MyDbContext context = new MyDbContext("Data Source=(local);Initial Catalog=SO24542133;Integrated Security=True;");
                CreateTestData(context);
                Expression<Func<SomeEntity, IEnumerable<AuditLog>>> ddd = entity => context.AuditLogSet.Where(a => a.TableName == "SomeEntity" && entity.Id == a.EntityId).DefaultIfEmpty();
                var result = GetEntities(context.SomeEntitySet, ddd).ToList();
                // Examine results here
                result.ToString();
            }        
        }
    }
