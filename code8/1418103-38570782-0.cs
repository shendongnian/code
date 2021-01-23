    public void Reverse()
    {
	   if (count < 2)
		return;
		
	   Node<T> node = headerNode;
       do
       {
			temp = node.NextNode;
			node.NextNode = node.PreviousNode;
			node.PreviousNode = temp;
			node = temp;
       }
	   while (temp != headerNode)
    }
