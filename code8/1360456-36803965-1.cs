    public class EditDataRepository : IEditDataRepository, IDisposable
    {
        private DBEntities db = new DBEntities();
        public void Edit(FormViewModel model)
        {            
            db.MyProcedure(model.Field1,model.Field2);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
