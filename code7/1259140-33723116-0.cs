    public class GeneralService
    {
        public void Delete<T>( T model ) 
        {
            DbIslemler<T> islem = new DbIslemler<T>();
            islem.Delete(model);
        }
    }
