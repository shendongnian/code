    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    
    namespace Stackoverflow
    {
        public class EntityContext : DbContext
        {
            public IDbSet<Conference> Conferences { get; set; }
            public IDbSet<Option> Options { get; set; }
            public IDbSet<User> Users { get; set; }
        }
    
        public class Option
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<Conference> Conference { set; get; }
        }
    
        public class Conference
        {
            // In one-to-one relation one end must be principal and second end must be dependent. 
            // User is the one which will be inserted first and which can exist without the dependent one. 
            // Conference end is the one which must be inserted after the principal because it has foreign key to the principal.
    
            [Key, ForeignKey("User")]
            public int UserId { get; set; }
            public int OptionId { get; set; }
            public virtual Option Option { set; get; }
            public virtual User User { get; set; }
        }
    
        public class User
        {
            // user requires a key
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual Conference Conference { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var entityContext = new EntityContext())
                {
                    // added to facilitate your example
                    var newOption = new Option {Name = "SomeOptionName"};
                    entityContext.Options.Add(newOption);
                    entityContext.SaveChanges();
    
                    var option = entityContext.Options.Find(newOption.Id);
    
                    var user = new User
                    {
                        Name = "Name",
                        Conference = new Conference
                        {
                            Option = option
                        }
                    };
    
                    // need to add the user
                    entityContext.Users.Add(user);
    
                    //...
                    entityContext.SaveChanges();
                }
            }
        }
    }
