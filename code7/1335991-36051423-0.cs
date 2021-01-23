    public class Meal
        {
            public int Id { get; set; }
            public virtual ICollection<Course> Courses { get; set; }
        }
        public class Course
        {
            public int Id { get; set; }
            public int MealId { get; set; }
            public virtual Meal Meal{ get; set; }
            public virtual ICollection<Ingredient> Ingredients { get; set; }
        }
        public class Ingredient
        {
            public int Id { get; set; }
            public virtual ICollection<Course> Courses { get; set; }
        }
