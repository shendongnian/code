    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Text;
    using System.Runtime.Remoting.Contexts;
    
    namespace AlbumSong2.Model
    {
        public class AlbumDbContext : DbContext
        {
            public AlbumDbContext() : base("AlbumDbConnection2") { }
            public IDbSet<Singer> Singers { get; set; }
            public IDbSet<Album> Albums { get; set; }
            public IDbSet<Song> Songs { get; set; }
    
    
            public override int SaveChanges()
            {
                try
                {
                    return base.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var sb = new StringBuilder();
    
                    foreach (var failure in ex.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }
    
                    throw new DbEntityValidationException(
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString(), ex
                    ); // Add the original exception as the innerException
                }
            }
        }
    }
