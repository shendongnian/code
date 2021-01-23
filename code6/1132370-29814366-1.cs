    public class LinkedList : IEnumerable<object>
    {
    		// your code
            // ....
    		public IEnumerator<object> GetEnumerator()
    		{
    			var current = this.head;
    
    			while (current != null)
    			{
    				yield return current.data;
    				current = current.next;
    			}
    		}
    
    		IEnumerator IEnumerable.GetEnumerator()
    		{
    			return this.GetEnumerator();
    		}
    }
