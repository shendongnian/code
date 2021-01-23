    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    namespace Tests
    {
    	public class MyBindingList<T> : BindingList<T>
    	{
    		static readonly Dictionary<string, Func<IEnumerable<T>, IEnumerable<T>>> orderByMethodCache = new Dictionary<string, Func<IEnumerable<T>, IEnumerable<T>>>();
    		private static Func<IEnumerable<T>, IEnumerable<T>> GetOrderByMethod(PropertyDescriptor prop, ListSortDirection direction)
    		{
    			var orderByMethodName = direction == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending";
    			var cacheKey = typeof(T).GUID + prop.Name + orderByMethodName;
    			Func<IEnumerable<T>, IEnumerable<T>> orderByMethod;
    			if (!orderByMethodCache.TryGetValue(cacheKey, out orderByMethod))
    				orderByMethodCache.Add(cacheKey, orderByMethod = CreateOrderByMethod(prop, orderByMethodName));
    			return orderByMethod;
    		}
    		private static Func<IEnumerable<T>, IEnumerable<T>> CreateOrderByMethod(PropertyDescriptor prop, string orderByMethodName)
    		{
    			var source = Expression.Parameter(typeof(IEnumerable<T>), "source");
    			var item = Expression.Parameter(typeof(T), "item");
    			var member = Expression.Property(item, prop.Name);
    			var selector = Expression.Lambda(member, item);
    			var orderByMethod = typeof(Enumerable).GetMethods()
    				.Single(a => a.Name == orderByMethodName && a.GetParameters().Length == 2)
    				.MakeGenericMethod(typeof(T), member.Type);
    			var orderByExpression = Expression.Lambda<Func<IEnumerable<T>, IEnumerable<T>>>(
    				Expression.Call(orderByMethod, new Expression[] { source, selector }), source);
    			return orderByExpression.Compile();
    		}
    		List<T> originalList = new List<T>();
    		ListSortDirection sortDirection;
    		PropertyDescriptor sortProperty;
    		bool isSorted;
    		bool ignoreListChanged;
    		Func<T, bool> filter;
    		public MyBindingList() { }
    		public MyBindingList(IEnumerable<T> items) { Update(items); }
    		protected override bool SupportsSortingCore { get { return true; } }
    		protected override PropertyDescriptor SortPropertyCore { get { return sortProperty; } }
    		protected override ListSortDirection SortDirectionCore { get { return sortDirection; } }
    		protected override bool IsSortedCore { get { return isSorted; } }
    		public Func<T, bool> Filter
    		{
    			get { return filter; }
    			set
    			{
    				filter = value;
    				Refresh();
    			}
    		}
    		public void Update(IEnumerable<T> items)
    		{
    			originalList.Clear();
    			originalList.AddRange(items);
    			Refresh();
    		}
    		public void Refresh()
    		{
    			var items = originalList.AsEnumerable();
    			if (Filter != null)
    				items = items.Where(filter);
    			if (isSorted)
    				items = GetOrderByMethod(sortProperty, sortDirection)(items);
    
    			bool raiseListChangedEvents = RaiseListChangedEvents;
    			RaiseListChangedEvents = false;
    			base.ClearItems();
    			foreach (var item in items)
    				Add(item);
    			RaiseListChangedEvents = raiseListChangedEvents;
    			if (!raiseListChangedEvents) return;
    			ignoreListChanged = true;
    			ResetBindings();
    			ignoreListChanged = false;
    		}
    		protected override void OnListChanged(ListChangedEventArgs e)
    		{
    			if (!ignoreListChanged)
    				originalList = Items.ToList();
    			base.OnListChanged(e);
    		}
    		protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
    		{
    			var orderByMethod = GetOrderByMethod(prop, direction);
    			sortProperty = prop;
    			sortDirection = direction;
    			isSorted = true;
    			Refresh();
    		}
    		protected override void RemoveSortCore()
    		{
    			if (!isSorted) return;
    			isSorted = false;
    			Refresh();
    		}
    	}
    }
