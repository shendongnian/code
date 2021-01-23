    public class ProductComparer: IComparer 
    {
      int IComparer.Compare(object a, object b)
     {
        if(a.Id == b.Id)
          return 0;
        else
         return 1;
     }
    }
