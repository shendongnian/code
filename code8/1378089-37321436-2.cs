    public static bool ParenthesisAreValid(this string str)
    {
         if (string.IsNullOrEmpty(str))
             return true;
        
         var openParenthesis = 0;
        
         foreach (var c in str)
         {
             if (c == '(')
             {
                 openParenthesis++;
             }
             else if (c == ')')
             {
                 openParenthesis--;
             }
             
             if (openParenthesis < 0)
                return false;
         }
         return openParenthesis == 0;
    }
