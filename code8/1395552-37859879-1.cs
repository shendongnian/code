	public class BlogRepository : IBlogRepository
	{
		private NHibernate.ISession session;
		private NHibernate.ISession Session
		{
			get
			{
				if (session == null)
					session = NHibernateSessionHelper.GetSession();
				return session;
			}
		}
		public Blog Find(int id)
		{
			return Session.Get<Blog>(id);
		}
	}
