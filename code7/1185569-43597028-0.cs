    var interceptor = new ProgressInterceptor(progress);
    var session = sessionFactory.OpenSession(interceptor);
    var query = session.Query<Entity>()...
    interceptor.StartIntercept<Entity>(0, 100, query.Count());
    entities = query.Fetch(x => x.Chidren).ToList();
    interceptor.StopIntercept();
    public class ProgressInterceptor : EmptyInterceptor
    {
        IProgress<int> progress;
        int            count;
        double         start;
        double         end;
        double         factor;
        string         className;
        bool           active = false;
        public ProgressInterceptor(IProgress<int> progress)
        {
            this.progress = progress;
        }
        public void StartIntercept<T>(double start, double end, int steps)
        {
            count       = 0;
            this.start  = start;
            this.end    = end;
            factor      = (end - start) / steps;
            className   = typeof(T).FullName;
            active      = true;
        }
        public void StopIntercept()
        {
            active = false;
        }
        public override object Instantiate(string clazz, EntityMode entityMode, object id)
        {
            if (active && className == clazz)
            {
                count++;
                progress.Report((int)Math.Min(start + count * factor, end));
            }
            return base.Instantiate(clazz, entityMode, id);
        }
    }
