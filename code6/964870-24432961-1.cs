    public static List<Category> GetCategoriesForUser()
        {
            User currentUser = UserServices.GetLoggedInUser();
            IEnumerable<Category> userCategories = new List<Category>();
            using (var context = new PhotoEntities())
            {
                userCategories.addRange(context.Categories.Where(c => c.UserId == currentUser.Id).toList());
            }
            return userCategories;
        }
