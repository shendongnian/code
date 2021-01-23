    // Note following class is not serializable since we customized the serialization of LinkedList. 
    [System.Runtime.InteropServices.ComVisible(false)] 
    public sealed class LinkedListNode<T> {
        internal LinkedList<T> list;
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        internal T item;
        
        public LinkedListNode( T value) {
            this.item = value;
        }
 
        internal LinkedListNode(LinkedList<T> list, T value) {
            this.list = list;
            this.item = value;
        }
 
        public LinkedList<T> List {
            get { return list;}
        }
 
        public LinkedListNode<T> Next {
            get { return next == null || next == list.head? null: next;}
        }
 
        public LinkedListNode<T> Previous {
            get { return prev == null || this == list.head? null: prev;}
        }
 
        public T Value {
            get { return item;}
            set { item = value;}
        }
 
        internal void Invalidate() {
            list = null;
            next = null;
            prev = null;
        }           
    }  
