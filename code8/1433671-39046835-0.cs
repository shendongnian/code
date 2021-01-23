    public void addFront(ref node head, int value)
            {
                var tempNode = new node(value);
                tempNode.next = head;
                head = tempNode;
            }
.
    head.addFront(ref head, userNodeInput);
