	public class MyConsumer<T> {
		public MyConsumer(BlockingCollection<T> collection, Action<T> action) {
			_collection = collection;
			_action = action;
		}
		
		private readonly BlockingCollection<T> _collection;
		private readonly Action<T> _action;
		
		public void StartConsuming() {
			new Task(Consume).Start();
		}
		
		private void Consume() {
			while (true) {
				var obj = _collection.Take();
				_action(obj);
			}
		}
	}
