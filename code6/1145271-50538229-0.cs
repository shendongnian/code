          //Scheme may return http for https
           var scheme = request.Scheme;
           if(request.IsHttps) scheme= scheme.EnsureEndsWith("S");
         //General string extension   
         public static string EnsureEndsWith(this string str, string sEndValue, bool ignoreCase = true)
        {
            if (!str.EndsWith(sEndValue, CurrentCultureComparison(ignoreCase)))
            {
                str = str + sEndValue;
            }
            return str;
        }
