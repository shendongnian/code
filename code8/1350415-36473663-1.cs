    private static string tooltip1;
        public static string Tooltip1
        {
            get 
            {
                if (tooltip1 == null)
                {
                    tooltip1 = "";//get this value form Resources
                }
                return tooltip1; 
            }
            
        }
