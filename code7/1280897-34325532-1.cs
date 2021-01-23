    public class EpisodiosService : IService<Episodio>
    {
        private Context _context;
    
        public EpisodiosService(Context context)
        {
            _context = context;
        }
        ...
    }
