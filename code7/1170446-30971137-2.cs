      public static class BoolExtension{
        public static bool And(this Boolean first, bool second){
          first =  first && second;
          return first;
        }
         public static bool MultiAnd(this Boolean first, params bool[] others)
        {
            foreach (var b in others) first = first && b;
            return first;
        }
    }
