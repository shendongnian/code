    public class InstanceCache {
    		readonly Dictionary<Type, object> cache = new Dictionary<Type, object>();
		readonly object locker = new object();
		/// <summary>
		/// Gets or creates an instance using Activator.CreateInstance
		/// </summary>
		/// <param name="type">The type to instantiate</param>
		/// <returns>The instantiated object</returns>
		public object GetOrCreateInstance(Type type) {
			return GetOrCreateInstance(type, Activator.CreateInstance);
		}
		/// <summary>
		/// Gets or creates an instance using a custom factory
		/// </summary>
		/// <param name="type">The type to instantiate</param>
		/// <param name="factory">The custom factory</param>
		/// <returns>The instantiated object</returns>
		public object GetOrCreateInstance(Type type, Func<Type, object> factory) {
			object existingInstance;
			if(cache.TryGetValue(type, out existingInstance)) {
				return existingInstance;
			}
			lock(locker) {
				if (cache.TryGetValue(type, out existingInstance)) {
					return existingInstance;
				}
				var newInstance = factory(type);
				cache[type] = newInstance;
				return newInstance;
			}
		}
	}
