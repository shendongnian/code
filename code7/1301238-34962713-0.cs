    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    namespace TestApp
    {
      public class Company
      {
          [Key]
          public virtual Guid CompanyId { get; set; }
          public virtual Guid? MonitoringId { get; set; }
          [ForeignKey("MonitoringId")]
          [InverseProperty("Companies")]
          public virtual Monitoring ActiveMonitoring { get; set; }
          [InverseProperty("Company")]
          public virtual ICollection<Monitoring> Monitorings { get; set; }
      }
      public class Monitoring
      {
          [Key]
          public virtual Guid MonitoringId { get; set; }
          public virtual Guid CompanyId { get; set; }
          [ForeignKey("CompanyId")]
          [InverseProperty("Monitorings")]
          public virtual Company Company { get; set; }
          [InverseProperty("ActiveMonitoring")]
          public virtual ICollection<Company> Companies { get; set; }
      }
      public class DatabaseContext : DbContext
      {
          public DatabaseContext() : base("TestContext")
          {
          }
          public DbSet<Company> Companies { get; set; }
          public DbSet<Monitoring> Monitorings { get; set; }
      }
      class Program
      {
          static void Main(string[] args)
          {
              Company cmp = new Company();
              cmp.CompanyId = Guid.NewGuid();
              using (var db = new DatabaseContext())
              {
                  db.Companies.Add(cmp);                
                  db.Monitorings.Add(new Monitoring { CompanyId = cmp.CompanyId, MonitoringId = Guid.NewGuid() });
                  db.Monitorings.Add(new Monitoring { CompanyId = cmp.CompanyId, MonitoringId = Guid.NewGuid() });
                 var m1 = new Monitoring { CompanyId = cmp.CompanyId, MonitoringId = Guid.NewGuid() };
                db.Monitorings.Add(m1);
                  db.Companies.Add(new Company { CompanyId = Guid.NewGuid() ,MonitoringId = m1.MonitoringId });
                  db.SaveChanges();
              }
          }
      }
    }
