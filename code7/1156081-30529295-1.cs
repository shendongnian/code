    public bool CheckIfTypeIsRandom(Type typeKnownAtRuntime)
    {
         if (typeof(Random).IsAssignableFrom(typeKnownAtRuntime) 
         {
             return true;
         }
         return false;
    }
