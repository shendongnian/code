	private List<T> FindChildren<T>(DependencyObject startNode, List<T> results = null) where T : DependencyObject {
		if (results == null) results = new List<T>();
		int count = VisualTreeHelper.GetChildrenCount(startNode);
		for (int i = 0; i < count; i++) {
			DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
			if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T)))) {
				T realType = (T)current;
				results.Add(realType);
			}
			FindChildren<T>(current, results);
		}
		return results;
	}
