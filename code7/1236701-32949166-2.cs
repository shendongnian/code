    public static class CatExtensions
     {
            public static object GetObject(this Cat value)
            {
                return new
                {
                    Hunger = value.Hunger,
                    Sleepiness = value.Sleepiness
                }
            }
        }
