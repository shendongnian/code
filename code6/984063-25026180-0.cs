    public LinkedListNode<AddXmlNodeArgs> GetNextItemThreadSafe(LinkedListNode<AddXmlNodeArgs> prevItem) {
        LinkedListNode<AddXmlNodeArgs> nextItem;
        LinkedListNode<AddXmlNodeArgs> returnItem;
        lock(locker) { // Lock the entire method contents to make it atomic
          if (prevItem == null) {
            returnItem = tasks.First;
          }
 
          // *1
          nextItem = prevItem.Next;
         
          if (nextItem == null) { // *2
            wh.WaitOne();
            returnItem = prevItem.Next;
          }
          returnItem = nextItem;
        }
        return returnItem;
      }
    }
