	public interface IObj<T, TSelf> where TSelf : IObj<T, TSelf>
	{
		void Merge(TSelf other);
	}
	
	class A<T>: IObj<T, A<T>> {
		public void Merge(A<T> alreadyCasted) {
			
		}
	}
