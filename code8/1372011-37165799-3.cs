    public class CategoryService : BaseService
    {
        public IList<CategoryModel> GetActiveCategories()
        {
            var bucket = GetActiveCategoriesBucket();
            var categoriesEntities = _systemRepository.Category.GetAll(bucket);
            return CategoryMapper.MapToModels(categoriesEntities);
        }
        
        public RelationPredicateBucket GetActiveCategoriesBucket()
        {
            var bucket = new RelationPredicateBucket();
            bucket.PredicateExpression.Add(CategoryFields.IsDeleted == false);
            bucket.PredicateExpression.Add(CategoryFields.IsActive == true);
            return bucket;
        }
    }
