        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new MealContext())
            {
                var meal = new Model.Meal();
                var course = new Model.Course();
                var ingredient = new Model.Ingredient();
                var ingredient2 = new Model.Ingredient();
                course.Ingredients = new[] { ingredient, ingredient2 };
                meal.Courses = new[] { course };
                context.Meals.Add(meal);
                context.SaveChanges();
            }
        }
