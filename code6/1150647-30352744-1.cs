	public static class ExtensionMethods {
		public static void Set<T>(this List<T> list, int index, T element) {
			if (index < list.Count) {
				list[index] = element;
			} else {
				for (int i = list.Count; i < index; i++) {
					list.Add(default(T));
				}
				list.Add(element);
			}
		}
	}
