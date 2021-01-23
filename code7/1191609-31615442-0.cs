    public
    abstract    class   BaseEntityController<TDbContext, TEntityViewModel>
                where   TDbContext          : DbContext<TEntityViewModel>
                where   TEntityViewModel    : EntityViewModel
    {
        protected
        abstract    TDbContext  CreateContext();
    }
