    public static class CatExtension(this Cat value)
     {
            public static object GetObject()
            {
                return new
                {
                    Hunger = value.Hunger,
                    Sleepiness = value.Sleepiness
                }
            }
        }
