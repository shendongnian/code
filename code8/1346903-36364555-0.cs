    public static class Extensions
    {
        public static string ToStringCustom(this bool booleanValue)
        {
            if(booleanValue)
              return "You did it";
            else
              return "You didn't do id";
        }
    }
