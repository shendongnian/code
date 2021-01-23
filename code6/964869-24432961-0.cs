    public static List<Category> GetCategoriesForUser()
        {
            User currentUser = UserServices.GetLoggedInUser();
            IEnumerable<Category> userCategories = new List<Category>();
            using (var context = new PhotoEntities())
            {
                userCategories = context.Categories.Where(c => c.UserId == currentUser.Id);
            }
            return userCategories;
        }
