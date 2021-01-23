    using System.ComponentModel.DataAnnotations;
    public class Post
    {
        [Required]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required,MinLength(15)]
        public string Description { get; set; }
    }
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
