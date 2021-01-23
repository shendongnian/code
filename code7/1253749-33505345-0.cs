    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                using (var context = new TestDbContext())
                {
                    var teams = context.Teams.ToList();
                    var ideas = context.Ideas.ToList();
                    var portfolios = context.Portfolios.ToList();
                }
            }
        }
        public class TestDbContext : DbContext
        {
            public DbSet<Team> Teams { get; set; }
            public DbSet<Idea> Ideas { get; set; }
            public DbSet<Portfolio> Portfolios { get; set; }
        }
        public class Portfolio
        {
            [Key]
            [Column(Order = 1)]
            public int Id { get; set; }
            public string Name { get; set; }
            [Key, ForeignKey("Idea")]
            [Column(Order = 2)]
            public int IdeaId { get; set; }
        
            public virtual Idea Idea { get; set; }
            [Key, ForeignKey("Team")]
            [Column(Order = 3)]
            public int TeamId { get; set; }
        
            public virtual Team Team { get; set; }
        }
        public class Idea
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [Key, ForeignKey("Team")]
            public int TeamId { get; set; }
        
            public virtual Team Team { get; set; }
        }
        public class Team
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Portfolio> Portfolios { get; set; }
            [Key, ForeignKey("Idea")]
            public int IdeaId { get; set; }
        
            public virtual Idea Idea { get; set; }
        }
    }
