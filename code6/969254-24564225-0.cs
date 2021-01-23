        //can also sort to filter out best result
        public static IList<T> Get(Expression<Func<T, bool>> expression)
        {
            using (ISession session = OpenEngineSession())
            {
                return session.Query<T>().Where(expression).ToList();
            }
        }
