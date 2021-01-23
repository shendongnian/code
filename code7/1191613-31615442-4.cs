    public  class   Category : Entity<Category, Category.DbContext, Category.ViewModel>
    {
        pubic   class   DbContext : BaseDbContext
        {
            public  override    void            Create(CategoryViewModel entity)
            {
            }
            public  override    List<ViewModel> Read(ModifyData data)
            {
            }
            public  override    void            Update(CategoryViewModel entity)
            {
            }
            public  override    void            Delete(CategoryViewModel entity)
            {
            }
        }
        pubic   class   ViewModel : BaseViewModel
        {
        }
    }
