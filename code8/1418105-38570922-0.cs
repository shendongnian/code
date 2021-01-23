     public void Reverse()
       {
           var currNode = headerNode;
           do
           {
               var temp = currNode.NextNode;
               currNode.NextNode = currNode.PreviousNode;
               currNode.PreviousNode = temp;
               currNode = currNode.PreviousNode;
           } 
           while (currNode != headerNode);
       }
