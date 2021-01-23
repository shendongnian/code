     public static Material Get(MaterialQuality quality)
     {
       switch(quality)
       {
         case MaterialQuality.Low: 
            return Low;
         case MaterialQuality.Medium: 
            return Medium;
         case MaterialQuality.High: 
            return High;
       }
       throw new Exception("We should never go here");
    }
