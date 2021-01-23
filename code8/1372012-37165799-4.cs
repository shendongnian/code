    public class CategoryService : BaseService
    {
        public IList<CategoryModel> GetActiveCategories()
        {
            var bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(CategoryFields.IsDeleted == false);
            bucket.PredicateExpression.Add(CategoryFields.IsActive == true);
            var categoriesEntities = _systemRepository.Category.GetAll(bucket);
            return CategoryMapper.MapToModels(categoriesEntities);
        }
    }
