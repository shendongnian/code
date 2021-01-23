    public void Sort(ref LinkedList<int> list)
    {
        LinkedListNode<int> tempNode;
    
        for(tempNode = list.First.Next; tempNode!=null; tempNode=tempNode.Next)
        {
    
            LinkedListNode<int> sortedListBoundary = tempNode.Previous; 
            list.Remove(tempNode);
            while (sortedListBoundary != null && tempNode.Value < sortedListBoundary.Value)
            {
                sortedListBoundary = sortedListBoundary.Previous;
            }
            
            if(sortedListBoundary == null)
                list.AddFirst(tempNode);
            else
                list.AddAfter(sortedListBoundary, tempNode); 
        }
    }
