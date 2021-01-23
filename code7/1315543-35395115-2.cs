        public class Folder {
           [Key]
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           public int Id { get; set; }
           public string Name { get; set; }
           public List<Letter> Letters { get; set; } 
        }
        public class Letter {
           [Key]
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           public int Id { get; set; }
           public string Title { get; set; }
           public string Content { get; set; }
           public virtual Folder Folder { get; set; }
           public int FolderId { get; set; }
           public DateTime CreationDate { get; set; }
       }
       public class OutgoingLetter : Letter {
           public string AddressTo { get; set; }
       }
       public class ReceviedLetter : Letter {
           public string AddressFrom { get; set; }
       }
       
       public class MyDbContext : DbContext {
           public virtual DbSet<Folder> Folders { get; set; }
 
           public virtual DbSet<Letter> Letters { get; set; }
           protected override void OnModelCreating(DbModelBuilder modelBuilder)
           {
               base.OnModelCreating(modelBuilder);
               // Folder <-> Letters       
               modelBuilder.Entity<Letter>()
               .HasRequired(t => t.Folder)
               .WithMany(f => f.Letters)
               .HasForeignKey(t => t.FolderId)
               .WillCascadeOnDelete(true);
           }
       }
       // ...........................................
       // TODO: Insert three Folders and related Letters.
       // Delete Folders and Leterrs in a three different ways.
       // In all cases Letters deleted throught WillCascadeOnDelete constraint.
       static void Main(string[] args)
       {
            using (var dtCntx = new MyDbContext())
            {
                var folder1 = new Folder() { Name = "Folder1" };
                var letters1 = new List<Letter>() { 
                    new OutgoingLetter{Title = "Folder1-Letter1", CreationDate=DateTime.Now, Folder=folder1 },
                    new ReceviedLetter{Title = "Folder1-Letter2", CreationDate=DateTime.Now, Folder=folder1 }
                };
                var folder2 = new Folder() { Name = "Folder2" };
                var letters2 = new List<Letter>() { 
                    new OutgoingLetter{Title = "Folder2-Letter1", CreationDate=DateTime.Now, Folder=folder2 },
                    new ReceviedLetter{Title = "Folder2-Letter2", CreationDate=DateTime.Now, Folder=folder2 }
                };
                var folder3 = new Folder() { Name = "Folder3" };
                var letters3 = new List<Letter>() { 
                    new OutgoingLetter{Title = "Folder3-Letter1", CreationDate=DateTime.Now, Folder=folder3 },
                    new ReceviedLetter{Title = "Folder3-Letter2", CreationDate=DateTime.Now, Folder=folder3 }
                };
                dtCntx.Folders.Add(folder1);
                dtCntx.Letters.AddRange(letters1);
                dtCntx.Folders.Add(folder2);
                dtCntx.Letters.AddRange(letters2);
                dtCntx.Folders.Add(folder3);
                dtCntx.Letters.AddRange(letters3);
                dtCntx.SaveChanges();
            }
            int id = 0;
            using (var dtCntx = new MyDbContext())
                id = dtCntx.Folders.First().Id;
            // Remove [Folder] and related [Letters] without loading [Folder] from DB
            using (var dtCntx = new MyDbContext())
            {
                var folder = new Folder { Id = id };
                dtCntx.Folders.Attach(folder);
                dtCntx.Folders.Remove(folder);
                dtCntx.SaveChanges();
            }
            // Load [Folder] from DB and delete it
            using (var dtCntx = new MyDbContext())
            {
                var folder = dtCntx.Folders.FirstOrDefault();
                dtCntx.Folders.Remove(folder);
                dtCntx.SaveChanges();
            }
            // Load [Folder] and all related [Letters]. Delete [Folder] and [Letters]
            using (var dtCntx = new MyDbContext())
            {
                var folder = dtCntx.Folders.Include(f => f.Letters).FirstOrDefault();
                dtCntx.Folders.Remove(folder);
                dtCntx.SaveChanges();
            }
            Console.WriteLine("Successfully !!!");
            Console.ReadKey();
        }
     
