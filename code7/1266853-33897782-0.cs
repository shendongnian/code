    public class FirstParser: IErrorParser
    {
         public List<string> ParseErrorMessage(BaseClass base)
         {
            DerivedClass derived = (base as DerivedClass);
            if (derived == null)
            {
               // handle null value
            }
            ...
         }
    }
