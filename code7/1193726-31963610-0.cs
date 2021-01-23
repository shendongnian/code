	static class Helper
	{
		public static void Merge<T>(ICollection<T> source, ICollection<T> target)
		{
			foreach (var item in source) target.Add(item);
			source.Clear();
		}
		#region Using dynamic
		public static void MergeCollection(FieldInfo sourceMember, object sourceObject, FieldInfo targetMember, object targetObject)
		{
			var sourceCollection = sourceMember.GetValue(sourceObject);
			var targetCollection = targetMember.GetValue(targetObject);
			Merge((dynamic)sourceCollection, (dynamic)targetCollection);
		}
		#endregion
		#region Using reflection only
		public static void MergeCollection2(FieldInfo sourceMember, object sourceObject, FieldInfo targetMember, object targetObject)
		{
			var collectionType = targetMember.FieldType.GetInterfaces().Single(
				t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>)
			);
			var itemType = collectionType.GetGenericArguments()[0];
			var mergeMethod = MergeMethodInfo.MakeGenericMethod(itemType);
			var sourceCollection = sourceMember.GetValue(sourceObject);
			var targetCollection = targetMember.GetValue(targetObject);
			mergeMethod.Invoke(null, new[] { sourceCollection, targetCollection });
		}
		private static readonly MethodInfo MergeMethodInfo = GetGenericMethodDefinition(
			(ICollection<object> source, ICollection<object> target) => Merge(source, target)
		);
		private static MethodInfo GetGenericMethodDefinition<T1, T2>(Expression<Action<T1, T2>> e)
		{
			return ((MethodCallExpression)e.Body).Method.GetGenericMethodDefinition();
		}
		#endregion
		#region Test
		class MyCollection1<TKey, TValue> : Dictionary<TKey, TValue>, IEnumerable<TValue>
		{
			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() { return Values.GetEnumerator(); }
		}
		class MyCollection2<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, IEnumerable<TValue>
		{
			IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
			{
				IEnumerable<KeyValuePair<TKey, TValue>> e = this;
				return e.Select(item => item.Value).GetEnumerator();
			}
		}
		class MyClass1
		{
			public MyCollection1<int, string> Items1 = new MyCollection1<int, string>();
		}
		class MyClass2
		{
			public MyCollection2<int, string> Items2 = new MyCollection2<int, string>();
		}
		private static FieldInfo GetField<T, V>(Expression<Func<T, V>> e)
		{
			return (FieldInfo)((MemberExpression)e.Body).Member;
		}
		public static void Test()
		{
			var source = new MyClass1();
			for (int i = 0; i < 10; i++) source.Items1.Add(i + 1, new string((char)('A' + i), 1));
			var target = new MyClass2();
			var sourceField = GetField((MyClass1 c) => c.Items1);
			var targetField = GetField((MyClass2 c) => c.Items2);
			// Merge source into target using dynamic approach
			MergeCollection(sourceField, source, targetField, target);
			// Merge target back into source using reflection approach
			MergeCollection2(targetField, target, sourceField, source);
		}
		#endregion
	}
