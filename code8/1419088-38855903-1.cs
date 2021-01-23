     public class ContentService : IContentService
        {
            private readonly ISession _session;
    
            public ContentService(ISession session)
            {
                _session = session;
            }
    
            public IQueryable<Question> Questions
            {
                get { return _session.Query<Question>(); }
            }
        }
