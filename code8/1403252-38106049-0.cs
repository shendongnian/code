    public interface IOperations<T> where T : class
    {
        void AddTranslation(TranslationLocationEnum Location, T model);
    }
    public class ApplicationOne : IOperations<ApplicationOne>
    {
        public void AddTranslation(TranslationLocationEnum Location, ApplicationOne model)
        {
            throw new NotImplementedException();
        }
    }
    public class ApplicationTwo : IOperations<ApplicationTwo>
    {
        public void AddTranslation(TranslationLocationEnum Location, ApplicationTwo model)
        {
            throw new NotImplementedException();
        }
    }
