    //This is a open type:
    public class AbstractFeedController <T>
    {
       T[] m_Items; 
       public void Feed(T item)
       {...}
       public T ReturnFeed()
       {...}
    }
