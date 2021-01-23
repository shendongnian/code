        private static List<string> nFormat= new List<string>();
        
            void Awake()
            {
             nFormat.Add("");
             nFormat.Add("K");
             nFormat.Add("M");
             nFormat.Add("B");
            //...
            }
            
            public static string Double2dec(double value)
            {
                 int num = 0;
                 while (value >= 1000d)
                 {
                     num++;
                     value /= 1000d;
                 }
                 return value.ToString("F2") + nFormat[num];
            }
            
 
