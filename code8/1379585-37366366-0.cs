    public static class Constants
    {
        public const string Layer_ver_const = "23";
        public static readonly string apiHash_const;
        static Constants()
        {
           if(Layer_ver_const == "23")
           {
             apiHash_const = "111111";
           }
           else if(Layer_ver_const == "50")
           {
             apiHash_const = "222222";
           }
           else
           {
             apiHash_const = "333333";
           }
        }
    }
