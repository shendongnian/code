    public void Delete(int id)
    {
        using (var scope = new UnitOfWork(_container))
        {
            var entity = AuthorService.GetById(id, scope);
            scope.Container.Authors.DeleteObject(entity);
        }     
    }
    public  static class AuthorService
    {
        private static LibManagerContainer Container
        {
            get { return MF.MF.Get<LibManagerContainer>(); }
        }
    
        public static Author GetById(int id, UnitOfWork scope)
        {
            return Container.Authors.SingleOrDefault(x => x.Id == id);
        }
    
        public static Author GetByName(String name, UnitOfWork scope)
        {
            return Container.Authors.SingleOrDefault(x => x.Name == name);
        }
    }
