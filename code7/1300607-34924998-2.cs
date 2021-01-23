    using System.ComponentModel.DataAnnotations;
    // Your class
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MinLength(15),MyCustomCheck] // << Here is your custom validator
        public string Description { get; set; }
    }
    // Your factory methods
    public class MyFactory() {
         public bool AddPost() {
		 var post = new Post() { Id = 1, Name = null, Description = "This is my test post"};
            try {
				using (var db = new DbContext()) {
					db.Posts.Add(post);
					db.SaveChanges();
					return true;
				}
			} catch(System.Data.Entity.Validation.DbEntityValidationException e) {
				Console.WriteLine("Something went wrong....");
			} catch(MyCustomException e) {
				Console.WriteLine(" a Custom Exception was triggered from a custom data annotation...");
			}
			return false;
			
         }
    }
    // The custom attribute
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	sealed public class MyCustomCheckAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
			{
			  if (value instanceof string) {
				    throw new MyCustomException("The custom exception was just triggered....")
			  } else {
				return true;
			  }
			}
	}
	
    // Your custom exception
	public class MyCustomException : Exception() {}
