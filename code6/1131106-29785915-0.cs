    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    
    namespace College.Models
    {
        public class Student : IValidatableObject
        {
    		[Key]
    		public int StudentID { get; set; }
    		public string Name { get; set; }
            public virtual Room Room { get; set; }
    
            //validation:
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
    
                if (Room.Students.Count() > 20)
                    yield return new ValidationResult("Too many students in class", new[] { "RoomId" });
            }
    
    
        }
    public class Room
    {
        public Room()
        {
            Students = new List<Student>();
        }
		[Key]
		public int RoomID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Student> Students {get;set;}
		
    }
    }
