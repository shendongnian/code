    public class NHibernateConfig
    {
        public static Configuration Configure()
        {
            var cfg = Fluently.Configure()
                .Database(...)
                .Mappings(...)
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "thread_static"))
                .BuildConfiguration();
            return cfg;  
         }
    }
