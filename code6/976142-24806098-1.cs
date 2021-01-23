     PreBooking pb = GetParent<DataListItem>.Get(this) as PreBooking; 
 
      public class GetParent<T>
        {
            public static object Get(Control c)
            {
                Control p = c.Parent;
                while (p != null && !(p is T))
                {
                    p = p.Parent;
                }
                return p;
            }
        }
