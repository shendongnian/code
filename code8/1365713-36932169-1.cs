	public class Container {	
		private readonly ConcurrentDictionary<Type, object> _container = 
			new ConcurrentDictionary<Type, object>();
		
		public List<TModel> Get<TModel>() where TModel: ModelBase {
			return _container.GetOrAdd(typeof(TModel), t => new List<TModel>()) as List<TModel>;		
		}
	}
