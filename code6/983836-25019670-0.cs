    public class LinkedListNode {
        public LinkedListNode(object value) // I know this is constructor
            { 
               this.Value = value;
               Next = new LinkedListNode("test"); //DONT DO THIS!!!
            }
    
        public object Value { get; private set; } //member variable of type object
    
        public LinkedListNode Next { get; private set; }    //??? how can we declare a member variable type same as class name?? how does this works?
        public LinkedListNode Prev { get; internal set; } // class name us LinkedListNode and the member variable also has data-type LinkedListNode, im confused.
    }
