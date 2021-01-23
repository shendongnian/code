    public class DummyRepository : IRepository
    {
        private readonly Dictionary<Type, Object> _database;
        public DummyRepository()
        {
            _database = new Dictionary<Type, object>();
        }
        public void Add<T>( T entity ) where T : class
        {
            var table = GetEntityTable<T>();
            var entityBase = entity as BaseEntity;
            if ( entityBase == null )
                throw new NotImplementedException( "You must inherit from entity base" );
            if ( entityBase.Id == 0 )
            {
                var idToUse = table.Any() ? table.Max( x => ( x as BaseEntity ).Id ) + 1 : 1;
                typeof( BaseEntity ).GetProperty( "Id" ).SetValue( entityBase, idToUse );
                table.Add( entity );
            }
            else
            {
                var itemInList = table.FirstOrDefault( x => ( x as BaseEntity ).Id == entityBase.Id );
                if ( itemInList == null )
                    table.Add( entity );
                else
                {
                    var itemIndex = table.IndexOf( itemInList );
                    table[ itemIndex ] = entity;
                }
            }
        }
        private List<T> GetEntityTable<T>() where T : class
        {
            List<T> table;
            if ( _database.ContainsKey( typeof( T ) ) )
                table = (List<T>)_database[ typeof( T ) ];
            else
            {
                table = new List<T>();
                _database.Add( typeof( T ), table );
            }
            return table;
        }
        public T Get<T>( int id, params Expression<Func<T, object>>[] includes ) where T : BaseEntity
        {
            if ( !_database.ContainsKey( typeof( T ) ) )
                return null;
            return ( (List<T>)_database[ typeof( T ) ] ).FirstOrDefault( x => x.Id == id );
        }
        public IQueryable<T> GetAll<T>( params Expression<Func<T, object>>[] includes ) where T : class
        {
            if ( _database.ContainsKey( typeof( T ) ) )
                return ( (List<T>)_database[ typeof( T ) ] ).AsQueryable();
            return new List<T>().AsQueryable();
        }
        public void Remove<T>( T entity ) where T : class
        {
            if ( _database.ContainsKey( entity.GetType() ) )
                ( (IList)_database[ entity.GetType() ] ).Remove( entity );
        }
        public void SaveChanges() { }
    }
