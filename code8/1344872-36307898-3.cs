    public class DocumentTypeModelComparer: IComparer
    {
      int IComparer.Compare(object a, object b)
     {
       if(a.Id == b.ID)
         return 0;
       else
         return 1;
      }
    }
