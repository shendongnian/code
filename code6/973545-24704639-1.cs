    Dictionary<Type, IHookContainer<object>> containers = new Dictionary<Type, IHookContainer<object>>()
    {
        {
		    typeof(HookContainer<System.Func<object,object>>), new HookContainer<System.Func<object,object>>() as IHookContainer<object>
	    },
        {
		    typeof(HookContainer<System.Func<object,object,object>>),new HookContainer<System.Func<object,object,object>>() as IHookContainer<object>
	    },
        {
		    typeof(HookContainer<System.Func<object,object,object,object>>),new HookContainer<System.Func<object,object,object,object>>() as IHookContainer<object>
	    }
    };
    public string AddFilter<T>(string filterName, T action, string filterTag = null, int priority = 0)
    {
        KeyValuePair<string, T> data = new KeyValuePair<string, T>(filterTag, action);
        if (containers.ContainsKey(typeof(T)))
        {
            IHookContainer<T> container = containers[typeof(T)] as IHookContainer<T>;
            container.Add(filterName, dictPriority, data);
        }
        return filterTag;
    }
    public interface IHookContainer<T>
    {
        void Add(string filterName, int priority, KeyValuePair<string, T> action);
    }
    public class HookContainer<T> : IHookContainer<T>
    {
        Dictionary<string, OrderedDictionary<string, T>> dict = new Dictionary<string, OrderedDictionary<string, T>>();
        public void Add(string filterName, int priority, KeyValuePair<string, T> action)
        {
            if (dict[filterName].Count >= priority)
            {
                dict[filterName].Insert(priority, action);
            }
            else
            {
                dict[filterName].Add(action);
            }
        }
    }
