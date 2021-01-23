    public static class CatExtension(this Cat value)
     {
            public Cat GetObject()
            {
                return new
                {
                    Hunger = value.Hunger,
                    Sleepiness = value.Sleepiness
                }
            }
        }
