    public static class StringExtensions
    {
         public static string RemoveAllButFirst(this string s, string stuffToRemove)
	     {
               // Check if the stuff to replace exists and if not, return the 
               // original string
               var locationOfStuff = s.IndexOf(stuffToRemove);
               if (locationOfStuff < 0)
               {
                   return s;
               }
               // Calculate where to pull the first string from and then replace the rest of the string
               var splitLocation = locationOfStuff + stuffToRemove.Length;
               return s.Substring(0, splitLocation) +  (s.Substring(splitLocation)).Replace(stuffToRemove,"");
         }
    }
