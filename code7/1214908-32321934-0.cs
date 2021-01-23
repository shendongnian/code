     partial void mExpiration_Compute(ref string result)
     {
        DateTime a = mExpiryDate.AddMonths(-1);
        DateTime b = mExpiryDate;
        TimeSpan ts = b.Subtract(a);
   
         for (var c= ts.Days; c >= 0; c--)
         {
            result += c==0 ? c.ToString() : c+ ",";
         }
      }
