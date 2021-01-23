    bool isSorted = true;
    
    for(int i = 0;i < cglist.Count; i++)
    {
       if( i == cglist.Count - 1)
       {
          break;
       }
       if(cglist[i] > cglist[i + 1])
       {
          isSorted = false;
       }
       
    }
