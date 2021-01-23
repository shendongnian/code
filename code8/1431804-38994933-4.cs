    namespace CollectionBindingDemo
    {
    	public class CollectionList
    	{
    		private Random rnd = new Random();
    		public ObservableCollection<int> IntegerNumbers { get; } = new ObservableCollection<int>();
    
    
    		public void Add()
    		{
    			IntegerNumbers.Add(rnd.Next(1000));
    		}
    		public void Remove(int i)
    		{
    			IntegerNumbers.Remove(i);
    		}
    	}
    }
