    public class FirstParser: IErrorParser
    {
         public List<string> ParseErrorMessage(BaseClass baseObj)
         {
            DerivedClass derived = (baseObj as DerivedClass);
            if (derived == null)
            {
               // handle null value
            }
            ...
         }
    }
