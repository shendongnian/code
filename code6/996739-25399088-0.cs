    public void Insert(T data, int index)
    {
        Node<T> replacedItem = new Node<T>();
        Node<T> newItem = new Node<T>(data);
    
        if (head == null)
        {
            head = new Node<T>(data);
            tail = head;
            count++;
        }
        else
        {
            Node<T> current = head;
            Node<T> tempNode = new Node<T>();
            if (index > 0 && index <= count + 1)
            {
                int c = 0;
                while (current != null)
                {
                    if (c == index)
                    {
                        tempNode = current;
                        current = newItem;
                        //update link from previous element
                        if(tempNode.Previous != null) 
                           tempNode.Previous.Next = current;
 
                        current.Next = tempNode;
                        current.Previous = tempNode.Previous;
                        tempNode.Previous = current;
                        count++;
                        break;
                    }
                    else
                    {
                        current = current.Next;
                    }
                    c++;
                }
            }             
        }
    }
