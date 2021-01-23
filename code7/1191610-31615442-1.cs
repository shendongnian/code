    public  class   CategoryController : BaseEntityController<CategoryDbContext, CategoryViewModel>
    {
        protected
        abstract    TDbContext  CreateContext();
    }
