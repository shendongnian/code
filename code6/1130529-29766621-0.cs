    public class BaseRepository
    {
        private IConfigurationContext context;
        public BaseRepository(IConfigurationContext context)
        {
            this.context = context;
        }
        //...
    }
