    public class MyLinkedList : IEnumerable<int>
    {
        // your code here
        public IEnumerator<int> GetEnumerator()
        {
            Node current = headNode;
            while(current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
