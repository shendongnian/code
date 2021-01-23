    public class CategoryRepository : ConfigurationBasedRepository<CategoryData, int>,    ICategoryRepository
    {
        public CategoryRepository(EntitiesDbOne ctxOne, EntitiesDbTwo ctxTwo)
        {
        }
    }
