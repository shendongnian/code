    public static class CustomObjectFactory
    {
        public static ICustomObject GetCustomObject(string ObjectName)
        {
            
            switch (ObjectName)
            {
                case "Object 1":
                    return new Object1();
                    
                    
                case "Object 2":
                    return new Object2();
                    
            }
            return null;
        }
    }
