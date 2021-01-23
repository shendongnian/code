    public bool Seq_Check(int[] elems, int k)
    {
        for(int i=elems.Length;i>0;i--)
        {
           //we found the first element we are looking for
           //so need to start looking for the rest of the sequence
           if(elems[i]==k)
           {
                // don't create a new index, we can reuse i
                int curr = k-1;
                for(;i>0 && curr>0;i--)
                {
                    if(elems[i]!=curr) 
                    {
                         if(elems[i]==k)
                         {
                             //reinitialize if we found K again
                             curr=k-1;
                             continue;
                         }
                         break;
                    }
                      
                    curr--;
                }
                
                // if the curr value is 0 then 
                // we found all the elements
                if(curr == 0)
                {
                    return true;
                }
           }
        }
       
        //no matching sequence was found so return false
        return false;
    }
