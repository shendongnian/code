	public class MyClass {
		private readonly HashSet<string> _referencedColumns;
		public IReadonlyHashSet<string> ReferencedColumns => _referencedColumns.AsReadOnly();
	}
	/// <summary>Represents hash set which don't allow for items addition.</summary>
	/// <typeparam name="T">Type of items int he set.</typeparam>
	public interface IReadonlyHashSet<T> : IReadOnlyCollection<T> {
		/// <summary>Returns true if the set contains given item.</summary>
		public bool Contains(T i);
	}
	/// <summary>Wrapper for a <see cref="HashSet{T}"/> which allows only for lookup.</summary>
	/// <typeparam name="T">Type of items in the set.</typeparam>
	public class ReadonlyHashSet<T> : IReadonlyHashSet<T> {
		/// <inheritdoc/>
		public int Count => set.Count;
		private HashSet<T> set;
		/// <summary>Creates new wrapper instance for given hash set.</summary>
		public ReadonlyHashSet(HashSet<T> set) => this.set = set;
		/// <inheritdoc/>
		public bool Contains(T i) => set.Contains(i);
		/// <inheritdoc/>
		public IEnumerator<T> GetEnumerator() => set.GetEnumerator();
		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => set.GetEnumerator();
	}
	/// <summary>Extension methods for the <see cref="HashSet{T}"/> class.</summary>
	public static class HasSetExtensions {
		/// <summary>Returns read-only wrapper for the set.</summary>
		public static ReadonlyHashSet<T> AsReadOnly<T>(this HashSet<T> s)
			=> new ReadonlyHashSet<T>(s);
	}
