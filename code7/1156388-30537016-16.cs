        //Your class doesn't directly concern itself with logging implmentation;
        //that's something that is better left to a separate class, perhaps
        //a "Logger" utility class with static methods that are available to your class.
        public double? DistanceFrom(MyPoint p)
        {
            try
            {
                if (p != null)
                    return  Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));            
                return null;
            }
            catch(Exception ex)
            {
                 //**** Static helper class that can be called from other classes ****
                 Logger.LogError(ex);
                 //NOTE: Logger might encapsulate other logging methods like...
                 //Logger.LogInformation(string s)
                 //...so an extension method would be less natural, since Logger
                 //doesn't relate to a specific base type that you can create an
                 //extension method for.
            }
    }
