<!-- language: lang-css --
     public class a
        {
          
            public void test()
            {
               myQueryableOfMyClass = myQueryableOfMyClass.Where(a => Filter(begin, end, a));
            }
            public Boolean Filter(DateTime begin, DateTime end, DateTime date)
            {
                if(((begin == null) || (date >= begin)) && ((end == null) || (date <= end)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }​
