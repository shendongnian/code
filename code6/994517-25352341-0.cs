    List<Node> SortNodes(List<Node> nodes)
    {
       List<Node> sortedNodes = new List<Node>();
       int length = nodes.Count; // The length gets less and less every time, but we still need all the numbers!
       int a = 0; // The current number we are looking for
       
       while (a < length)
       {
          for (int i = 0; i < nodes.Count; i++)
          {
             // if the node's number is the number we are looking for, 
             if (nodes[i].number == a)
             {
                sortedNodes.Add(list[i]); // add it to the list
                nodes.RemoveAt(i); // and remove it so we don't have to search it again.
                a++; // go to the next number
                break; // break the loop
             }
          }
       }
    
       return sortedNodes;
    }
