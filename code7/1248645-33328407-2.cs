       public class iCnF()
       {
        public static System.Boolean IsNumeric(System.Object Expression) 
          {
            if (Expression == null || Expression is DateTime)
                return false;
            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;
            try 
            {
                if(Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                    return true;
            } catch {} // just dismiss errors but return false
                return false;
         }
    }
