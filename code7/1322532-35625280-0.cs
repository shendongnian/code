    public class LinkedList<T>
    {
        public class Node<T>
        {
            public T data;
            public Node<T> next;
        }
        //structure
        private Node<T> head;
        private T count;
        public LinkedList()
        {
            //constructor
        }
        public bool IsEmpty
        {
            //check if list is empty or not
        }
        public int Count
        {
            //count items in the list
        }
        public T Add(int index, T o)
        {
            //add items to the list from beginning/end  
        }
        public T Delete(int index)
        {
            //delete items to the list from beginning/end   
        }
        public void Clear()
        {
            //clear the list    
        }
    }
