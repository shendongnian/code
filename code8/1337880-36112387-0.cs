    public bool Contains( Object obj )
            {
                for( Node curr = Start; curr != null; curr = curr.Next)
                {
                   if(curr.data is workman && obj is workman)
                    {
                        if((workman)curr.data == (workman)obj )
                        {
                            return true;
                        }
                        else
                        {
                         return false;
                        }
                    }
                   if( curr.Data == obj )
                   {
                       return true;
                   }
                }
                return false;
            }
